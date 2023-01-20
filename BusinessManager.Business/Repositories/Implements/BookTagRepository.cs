using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BusinessManager.Business.Repositories.Implements
{
    public class BookTagRepository : Repository<BookTagDTO, BookTag>, IBookTagRepository
    {

        public BookTagRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public async Task<BookTagDTO?> UpdateAsync(BookTagDTO entity)
        {
            var objFromDb = await _db.BookTag.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = entity.Name;
                objFromDb.UpdatedDate = DateTimeOffset.UtcNow;
                var result = await Task.Run(() => _db.Update(objFromDb));
                return _mapper.Map<BookTagDTO>(result.Entity);
            }

            return null;
        }
    }
}
