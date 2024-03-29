﻿using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using BusinessManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public new async Task<bool> CreateAsync(BookDTO entity)
        {
            Book obj = _mapper.Map<Book>(entity);
            
            try
            {
                var tags = await _db.Tag.Where(tag => entity.Tags!.Select(t => t.Id).Contains(tag.Id)).ToListAsync();
                obj.Tags = tags;
                dbSet.Attach(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BookDTO entity)
        {
            try
            {
                var obj = await _db.Book.Include(b => b.Tags).SingleOrDefaultAsync(book => book.Id == entity.Id);
                var tagIds = entity.Tags!.Select(s => s.Id);
                var tags = _db.Tag.Where(tag => tagIds.Contains(tag.Id)).ToList();
                if (obj != null)
                {
                    obj.Title = entity.Title;
                    obj.Description = entity.Description;
                    obj.Avatar = entity.Avatar;
                    obj.AuthorId = entity.AuthorId ?? 0;
                    obj.PublisherId = entity.PublisherId ?? 0;
                    obj.SizeId = entity.SizeId ?? 0;
                    obj.Price = entity.Price;
                    obj.Discount = entity.Discount;
                    obj.PublishedDate = entity.PublishedDate ?? DateTime.Now;
                    obj.UpdatedDate = DateTime.Now;
                    obj.Tags = tags;
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }
    }
}
