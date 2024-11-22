using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _dbContext;
        public BookRepository(LibraryContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Book> GetByFilterAsync(Expression<Func<Book, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Book> books = _dbContext.Books.Include(x => x.Loans).Include(x => x.Reviews);
            if (!tracked == true)
            {
                books = books.AsNoTracking();
            }
            if (filter != null)
            {
                books = books.Where(filter);
            }
            return await books.Select(b => new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Genre = b.Genre,
                Description = b.Description,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable,
                DigitalUrl = b.DigitalUrl,
                ImageUrl = b.ImageUrl,
                PublishedDate = b.PublishedDate,
                Loans = b.Loans,
                Reviews = b.Reviews
                //.Select(r => new Review
                //{
                //    Id = r.Id,
                //    Rating = r.Rating,
                //    Comment = r.Comment,
                //    ReviewDate = r.ReviewDate,
                //    UserId = r.UserId,
                //    User = r.User
                //}).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetListAsync(Expression<Func<Book, bool>> filter = null)
        {
            IQueryable<Book> books = _dbContext.Books.Include(x=>x.Loans).Include(x=>x.Reviews);
            if (filter != null)
            {
                books = books.Where(filter);
            }
            return await books.Select(b => new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Genre = b.Genre,
                Description = b.Description,
                ISBN = b.ISBN,
                IsAvailable = b.IsAvailable,
                DigitalUrl = b.DigitalUrl,
                ImageUrl = b.ImageUrl,
                PublishedDate = b.PublishedDate,
                //Loans = b.Loans,
                //Reviews = b.Reviews
            }).ToListAsync();
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public Task<Book> DeleteAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
