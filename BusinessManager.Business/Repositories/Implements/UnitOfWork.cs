using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.DAOs;
using BusinessManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            BookTag = new BookTagRepository(db, mapper);
        }
        public IBookTagRepository BookTag { get; private set; }

        public void Dispose() => _db.Dispose();

        public async Task DisposeAsync()
        {
           await _db.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
