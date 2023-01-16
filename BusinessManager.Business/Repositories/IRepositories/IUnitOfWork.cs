using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookTagRepository BookTag { get; }
        Task SaveAsync();
    }
}
