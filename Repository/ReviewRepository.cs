using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly LibraryContext _dbContext;
        public ReviewRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Review> GetByFilterAsync(Expression<Func<Review, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Review> reviews = _dbContext.Reviews.Include(x => x.User).Include(x => x.Book);
            if (!tracked == true)
            {
                reviews = reviews.AsNoTracking();
            }
            if (filter != null)
            {
                reviews = reviews.Where(filter);
            }
            return await reviews.Select(r => new Review
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate,
                UserId = r.UserId,
                User = r.User,
                BookId = r.BookId,
                Book = r.Book,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetListAsync(Expression<Func<Review, bool>> filter = null)
        {
            IQueryable<Review> reviews = _dbContext.Reviews.Include(x => x.User).Include(x => x.Book);
            if (filter != null)
            {
                reviews = reviews.Where(filter);
            }
            return await reviews.Select(r => new Review
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate,
                UserId = r.UserId,
                User = r.User,
                BookId = r.BookId,
                Book = r.Book,
            }).ToListAsync();
        }

        public async Task<Review> CreateAsync(Review entity)
        {
            await _dbContext.Reviews.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public Task<Review> DeleteAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> UpdateAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
