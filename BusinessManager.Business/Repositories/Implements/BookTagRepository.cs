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
    public class BookTagRepository : Repository<BookTagDTO, BookTag>, IBookTagRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public BookTagRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BookTagDTO?> UpdateAsync(BookTagDTO entity)
        {
            var objFromDb = await _db.BookTag.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = entity.Name;
                objFromDb.UpdatedDate = DateTimeOffset.UtcNow;
                await Task.Run(() => _db.Update(objFromDb));
                return _mapper.Map<BookTagDTO>(objFromDb);
            }

            return null;
        }
    }
}
