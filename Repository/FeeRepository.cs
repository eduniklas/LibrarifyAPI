using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class FeeRepository : IRepository<Fee>
    {
        private readonly LibraryContext _dbContext;
        public FeeRepository(LibraryContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Fee> GetByFilterAsync(Expression<Func<Fee, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Fee> fees = _dbContext.Fee.Include(x => x.User).Include(x => x.Loan);
            if (!tracked == true)
            {
                fees = fees.AsNoTracking();
            }
            if (filter != null)
            {
                fees = fees.Where(filter);
            }
            return await fees.Select(f => new Fee
            {
                Id = f.Id,
                Amount = f.Amount,
                IsPaid = f.IsPaid,
                IssueDate = f.IssueDate,
                LoanId = f.LoanId,
                Loan = f.Loan,
                UserId = f.UserId,
                User = f.User,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<Fee>> GetListAsync(Expression<Func<Fee, bool>> filter = null)
        {
            IQueryable<Fee> fees = _dbContext.Fee.Include(x => x.User).Include(x => x.Loan);
            if (filter != null)
            {
                fees = fees.Where(filter);
            }
            return await fees.Select(f => new Fee
            {
                Id = f.Id,
                Amount = f.Amount,
                IsPaid = f.IsPaid,
                IssueDate = f.IssueDate,
                LoanId = f.LoanId,
                Loan = f.Loan,
                UserId = f.UserId,
                User = f.User,
            }).ToListAsync();
        }

        public async Task<Fee> CreateAsync(Fee entity)
        {
            await _dbContext.Fee.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public Task<Fee> DeleteAsync(Fee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Fee> UpdateAsync(Fee entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
