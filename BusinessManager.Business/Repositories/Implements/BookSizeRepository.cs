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
    public class BookSizeRepository : Repository<BookSizeDTO, BookSize>, IBookSizeRepository
    {

        public BookSizeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public async Task<BookSizeDTO?> UpdateAsync(BookSizeDTO entity)
        {
            var objFromDb = await _db.BookSize.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (objFromDb != null)
            {
                objFromDb.SizeValue = entity.SizeValue;
                objFromDb.UpdatedDate = DateTimeOffset.UtcNow;
                var result = await Task.Run(() => _db.Update(objFromDb));
                return _mapper.Map<BookSizeDTO>(result.Entity);
            }

            return null;
        }
    }
}
