using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IPublisherRepository : IRepository<PublisherDTO,Publisher>
    {
        Task<PublisherDTO?> UpdateAsync(PublisherDTO entity);
    }
}
