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
    public class BookImageRepository : Repository<BookImageDTO, BookImage>, IBookImageRepository
    {
        public BookImageRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public Task<BookImageDTO?> UpdateAsync(BookImageDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
