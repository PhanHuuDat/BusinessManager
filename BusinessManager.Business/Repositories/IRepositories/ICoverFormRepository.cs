using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface ICoverFormRepository : IRepository<CoverFormDTO,CoverForm>
    {
        Task<CoverFormDTO?> UpdateAsync(CoverFormDTO entity);
    }
}
