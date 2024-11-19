using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly LibraryContext _dbContext;
        public LoanRepository(LibraryContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Loan> GetByFilterAsync(Expression<Func<Loan, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Loan> loans = _dbContext.Loans.Include(x => x.User).Include(x => x.Book);
            if (!tracked == true)
            {
                loans = loans.AsNoTracking();
            }
            if (filter != null)
            {
                loans = loans.Where(filter);
            }
            return await loans.Select(l => new Loan
            {
                Id = l.Id,
                UserId = l.UserId,
                User = l.User,
                BookId = l.BookId,
                Book = l.Book,
                DueDate = l.DueDate,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                IsExtended = l.IsExtended,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<Loan>> GetListAsync(Expression<Func<Loan, bool>> filter = null)
        {
            IQueryable<Loan> loans = _dbContext.Loans.Include(x=>x.User).Include(x=>x.Book);
            if (filter != null) 
            {
                loans = loans.Where(filter);
            }
            return await loans.Select(l => new Loan
            {
                Id = l.Id,
                UserId = l.UserId,
                User = l.User,
                BookId = l.BookId,
                Book = l.Book,
                DueDate = l.DueDate,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                IsExtended = l.IsExtended,
            }).ToListAsync();
        }

        public async Task<Loan> CreateAsync(Loan entity)
        {
            await _dbContext.Loans.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public Task<Loan> UpdateAsync(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Task<Loan> DeleteAsync(Loan entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
