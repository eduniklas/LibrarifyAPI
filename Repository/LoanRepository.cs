using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class LoanRepository : ILoanRepository
    {
        LibraryContext _dbContext;
        public LoanRepository(LibraryContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Loan>> GetLoansList(Expression<Func<Loan, bool>> filter = null)
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
                LoanDate = l.DueDate,
                ReturnDate = l.ReturnDate,
                IsExtended = l.IsExtended,
            }).ToListAsync();
        }
    }
}
