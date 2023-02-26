using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> UpdateAsync(PublisherDTO entity)
        {
            var objFromDb = await _db.Publisher.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = entity.Name;
                objFromDb.Address = entity.Address;
                objFromDb.Phone = entity.Phone;
                objFromDb.UpdatedDate = DateTime.Now;
                var result = await Task.Run(() => _db.Update(objFromDb));
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
