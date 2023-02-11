using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IAuthorRepository : IRepository<AuthorDTO,Author>
    {
        Task<bool> UpdateAsync(AuthorDTO entity);
    }
}
