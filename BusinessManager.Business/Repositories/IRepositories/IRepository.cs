using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;
using System.Linq.Expressions;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IRepository<T, U> where T : BaseDTO where U : BaseDAO
    {
        Task<T?> CreateAsync(T entity);
        Task<bool> DeleteAsync(int entityId);
        Task<bool> DeleteRangeAsync(IEnumerable<int> entites);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<U, bool>>? filter = null,
            Func<IQueryable<U>, IOrderedQueryable<U>>? orderby = null,
            string? includeProperties = null);
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<U, bool>>? filter = null, string? includeProperties = null);
    }
}
