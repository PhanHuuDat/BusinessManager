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
            var obj = await _db.Book.FirstOrDefaultAsync(book => book.Id == entity.Id);
            if (obj != null)
            {
                obj.Title = entity.Title;
                obj.Description = entity.Description;
                obj.Avatar = entity.Avatar;
                obj.AuthorId = entity.AuthorId??0;
                obj.PublisherId = entity.PublisherId??0;
                obj.BookSizeId = entity.BookSizeId??0;
                obj.Price = entity.Price;
                obj.Discount = entity.Discount;
                obj.PublishedDate = entity.PublishedDate??DateTime.Now;
                obj.UpdatedDate = DateTimeOffset.UtcNow;
                return _mapper.Map<BookDTO>(obj);
            }

            return null;
        }
    }
}
