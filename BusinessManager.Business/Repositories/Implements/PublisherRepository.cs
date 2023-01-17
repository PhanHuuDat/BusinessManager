using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.Implements
{
    public class PublisherRepository : Repository<PublisherDTO, Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public Task<PublisherDTO> UpdateAsync(PublisherDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
