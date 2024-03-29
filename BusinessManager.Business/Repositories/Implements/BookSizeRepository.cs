﻿using AutoMapper;
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
    public class BookSizeRepository : Repository<BookSizeDTO, Size>, IBookSizeRepository
    {

        public BookSizeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public async Task<bool> UpdateAsync(BookSizeDTO entity)
        {
            var objFromDb = await _db.Size.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (objFromDb != null)
            {
                objFromDb.SizeValue = entity.SizeValue;
                objFromDb.UpdatedDate = DateTime.Now;
                var result = await Task.Run(() => _db.Update(objFromDb));
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
