using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IPublisherRepository : IRepository<PublisherDTO,Publisher>
    {
        Task<bool> UpdateAsync(PublisherDTO entity);
    }
}
