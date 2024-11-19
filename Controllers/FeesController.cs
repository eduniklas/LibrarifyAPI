using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;

namespace LibrarifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly IRepository<Fee> _repository;

        public FeesController(LibraryContext context, IRepository<Fee> repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Fees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fee>>> GetFee()
        {
            return await _repository.GetListAsync();
        }

        // GET: api/Fees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fee>> GetFee(int id)
        {
            var fee = await _repository.GetByFilterAsync(x=>x.Id == id);

            if (fee == null)
            {
                return NotFound();
            }

            return fee;
        }

        // PUT: api/Fees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFee(int id, Fee fee)
        {
            if (id != fee.Id)
            {
                return BadRequest();
            }

            _context.Entry(fee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fee>> PostFee(Fee fee)
        {
            await _repository.CreateAsync(fee);

            return CreatedAtAction("GetFee", new { id = fee.Id }, fee);
        }

        // DELETE: api/Fees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = await _context.Fee.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }

            _context.Fee.Remove(fee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeeExists(int id)
        {
            return _context.Fee.Any(e => e.Id == id);
        }
    }
}
