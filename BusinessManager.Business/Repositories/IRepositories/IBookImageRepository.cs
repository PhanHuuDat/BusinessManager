using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookImageRepository : IRepository<BookImageDTO,BookImage>
    {
        Task<BookImageDTO?> UpdateAsync(BookImageDTO entity);
    }
}
