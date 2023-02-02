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
    public class BookRepository : Repository<BookDTO, Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public async Task<BookDTO?> UpdateAsync(BookDTO entity)
        {
            var obj = await _db.Book.FirstOrDefaultAsync(book => book.ID == entity.ID);
            if (obj != null)
            {
                obj.Title = entity.Title;
                obj.Description = entity.Description;
                obj.Avatar = entity.Avatar;
                obj.AuthorId = entity.AuthorId;
                obj.CoverFormId = entity.CoverFormId;
                obj.PublisherId = entity.PublisherId;
                obj.BookSizeId = entity.BookSizeId;
                obj.Price = entity.Price;
                obj.Discount = entity.Discount;
                obj.PublishedDate = entity.PublishedDate;
                obj.UpdatedDate = DateTimeOffset.UtcNow;
                return _mapper.Map<BookDTO>(obj);
            }

            return null;
        }
    }
}
