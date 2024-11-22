using LibrarifyAPI.Data;
using LibrarifyAPI.Models;
using LibrarifyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository
{
    public class NotificationRepository : IRepository<Notification>
    {
        private readonly LibraryContext _dbContext;
        public NotificationRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Notification> GetByFilterAsync(Expression<Func<Notification, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Notification> notifications = _dbContext.Notifications.Include(x => x.User);
            if (!tracked == true)
            {
                notifications = notifications.AsNoTracking();
            }
            if (filter != null)
            {
                notifications = notifications.Where(filter);
            }
            return await notifications.Select(f => new Notification
            {
                Id = f.Id,
                Message = f.Message,
                IsRead = f.IsRead,
                SentDate = f.SentDate,
                UserId = f.UserId,
                User = f.User,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<Notification>> GetListAsync(Expression<Func<Notification, bool>> filter = null)
        {
            IQueryable<Notification> notifications = _dbContext.Notifications.Include(x => x.User);
            if (filter != null)
            {
                notifications = notifications.Where(filter);
            }
            return await notifications.Select(f => new Notification
            {
                Id = f.Id,
                Message = f.Message,
                IsRead = f.IsRead,
                SentDate = f.SentDate,
                UserId = f.UserId,
                User = f.User,
            }).ToListAsync();
        }

        public async Task<Notification> CreateAsync(Notification entity)
        {
            await _dbContext.Notifications.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<Notification> DeleteAsync(Notification entity)
        {
            _dbContext.Notifications.Remove(entity); // ???
            await SaveAsync();
            return entity;
        }

        public Task<Notification> UpdateAsync(Notification entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
