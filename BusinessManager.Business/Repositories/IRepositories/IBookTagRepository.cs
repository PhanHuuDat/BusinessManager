using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookTagRepository : IRepository<TagDTO, Tag>
    {
        Task<bool> UpdateAsync(TagDTO entity);
    }
}
