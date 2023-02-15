using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;
using System.Linq.Expressions;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IRepository<T, U> where T : BaseDTO where U : BaseDAO
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateRangeAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(int entityId);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entites);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null,
            string? includeProperties = null, bool isTracking = true);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<U, bool>>? filter = null,
            string? includeProperties = null, bool isTracking = true);
        

    }
}
