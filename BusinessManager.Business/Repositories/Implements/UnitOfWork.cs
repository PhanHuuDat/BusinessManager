using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.Data;

namespace BusinessManager.Business.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            Author = new AuthorRepository(db, mapper);
            Import= new ImportRepository(db, mapper);
            Book = new BookRepository(db, mapper);
            Size = new BookSizeRepository(db, mapper);
            Tag = new BookTagRepository(db, mapper);
            Publisher= new PublisherRepository(db, mapper);
        }

        public IAuthorRepository Author { get; private set; }
        public IImportRepository Import { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookSizeRepository Size { get; private set; }
        public IBookTagRepository Tag { get; private set; }
        public IPublisherRepository Publisher { get; private set; }

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
