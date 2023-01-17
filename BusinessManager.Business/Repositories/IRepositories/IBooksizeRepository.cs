using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookSizeRepository : IRepository<BookSizeDTO, BookSize>
    {
        Task<BookSizeDTO?> UpdateAsync(BookSizeDTO entity);
    }
}
