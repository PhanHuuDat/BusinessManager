using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookTagRepository : IRepository<BookTagDTO, BookTag>
    {
        Task<bool> UpdateAsync(BookTagDTO entity);
    }
}
