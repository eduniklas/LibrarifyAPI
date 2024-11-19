using LibrarifyAPI.Models;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task SaveAsync();
    }
}
