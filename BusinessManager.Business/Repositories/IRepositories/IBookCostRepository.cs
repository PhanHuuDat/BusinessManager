using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookCostRepository : IRepository<BookCostDTO,BookCost>
    {
        Task<bool> UpdateAsync(BookCostDTO entity);
    }
}
