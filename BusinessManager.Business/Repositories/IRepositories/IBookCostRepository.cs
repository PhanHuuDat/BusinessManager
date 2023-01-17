using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookCostRepository : IRepository<BookCostDTO,BookCost>
    {
        Task<BookCostDTO?> UpdateAsync(BookCostDTO entity);
    }
}
