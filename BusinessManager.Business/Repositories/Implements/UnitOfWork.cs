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

        public IAuthorRepository Author { get; private set; }
        public IBookCostRepository BookCost { get; private set; }
        public IBookImageRepository BookImage { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookSizeRepository BookSize { get; private set; }
        public IBookTagRepository BookTag { get; private set; }
        public ICoverFormRepository CoverForm { get; private set; }
        public IPublisherRepository Publisher { get; private set; }

        public void Dispose() => _db.Dispose();

        public async Task DisposeAsync()
        {
            await _db.DisposeAsync();
        }

    }
}
