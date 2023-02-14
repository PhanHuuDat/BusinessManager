using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookCostRepository : IRepository<ImportDTO,Import>
    {
        Task<bool> UpdateAsync(ImportDTO entity);
    }
}
