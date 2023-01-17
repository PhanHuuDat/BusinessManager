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
    public class BookRepository : Repository<BookDTO, Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }
        public Task<BookDTO> UpdateAsync(BookDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
