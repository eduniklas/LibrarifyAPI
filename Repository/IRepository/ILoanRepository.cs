using LibrarifyAPI.Models;
using System.Linq.Expressions;

namespace LibrarifyAPI.Repository.IRepository
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetLoansList(Expression<Func<Loan, bool>> filter = null);
    }
}
