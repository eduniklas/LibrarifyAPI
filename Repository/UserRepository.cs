using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly LibraryContext _dbContext;
        public UserRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter = null, bool tracked = true)
        {
            IQueryable<User> users = _dbContext.Users.Include(x => x.Loans).Include(x => x.Reviews);
            if (!tracked == true)
            {
                users = users.AsNoTracking();
            }
            if (filter != null)
            {
                users = users.Where(filter);
            }
            return await users.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Password = u.Password,
                DateJoined = u.DateJoined,
                IsAccountActive = u.IsAccountActive,
                Loans = u.Loans.Select(l=> new Loan
                {
                    Id=l.Id,
                    BookId=l.BookId,
                    LoanDate=l.LoanDate,
                    DueDate=l.DueDate,
                    IsExtended=l.IsExtended,
                    ReturnDate=l.ReturnDate,
                    Book = l.Book,
                }).ToList(),
                Reviews = u.Reviews.Select(r=> new Review
                {
                    Id=r.Id,
                    Rating=r.Rating,
                    Comment=r.Comment,
                    ReviewDate=r.ReviewDate,
                    Book=r.Book,
                }).ToList(),
            }).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> users = _dbContext.Users.Include(x => x.Loans).Include(x => x.Reviews);
            if (filter != null)
            {
                users = users.Where(filter);
            }
            return await users.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Password = u.Password,
                DateJoined = u.DateJoined,
                IsAccountActive = u.IsAccountActive,
                Loans = u.Loans.Select(l => new Loan
                {
                    Id = l.Id,
                    BookId = l.BookId,
                    LoanDate = l.LoanDate,
                    DueDate = l.DueDate,
                    IsExtended = l.IsExtended,
                    ReturnDate = l.ReturnDate,
                    Book = l.Book,
                }).ToList(),
                Reviews = u.Reviews.Select(r => new Review
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    ReviewDate = r.ReviewDate,
                    Book = r.Book,
                }).ToList(),
            }).ToListAsync();
        }
        public async Task<User> CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public Task<User> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
