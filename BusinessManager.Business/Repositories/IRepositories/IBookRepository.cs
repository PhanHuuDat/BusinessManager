using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookRepository : IRepository<BookDTO,Book>
    {
        Task<bool> UpdateAsync(BookDTO entity);
    }
}
