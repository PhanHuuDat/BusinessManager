using BusinessManager.DataAccess.DAOs;
using BusinessManager.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IBookSizeRepository : IRepository<BookSizeDTO, BookSize>
    {
    }
}
