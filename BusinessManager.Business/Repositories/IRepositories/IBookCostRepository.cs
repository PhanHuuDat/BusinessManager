using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookCostRepository : IRepository<BookCostDTO,Cost>
    {
        Task<bool> UpdateAsync(BookCostDTO entity);
    }
}
