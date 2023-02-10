using AutoMapper;
using BusinessManager.Business.Repositories.IRepositories;
using BusinessManager.DataAccess.Data;

namespace BusinessManager.Business.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            Author = new AuthorRepository(db, mapper);
            BookCost= new BookCostRepository(db, mapper);
            Book = new BookRepository(db, mapper);
            BookSize = new BookSizeRepository(db, mapper);
            BookTag = new BookTagRepository(db, mapper);
            Publisher= new PublisherRepository(db, mapper);
        }

        public IAuthorRepository Author { get; private set; }
        public IBookCostRepository BookCost { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookSizeRepository BookSize { get; private set; }
        public IBookTagRepository BookTag { get; private set; }
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
