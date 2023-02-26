using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IImportRepository : IRepository<ImportDTO,Import>
    {
        Task<bool> UpdateAsync(ImportDTO entity);
    }
}
