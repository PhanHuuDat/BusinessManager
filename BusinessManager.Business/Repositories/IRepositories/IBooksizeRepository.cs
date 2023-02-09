using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookSizeRepository : IRepository<BookSizeDTO, Size>
    {
        Task<bool> UpdateAsync(BookSizeDTO entity);
    }
}
