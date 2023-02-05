namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }
        IBookCostRepository BookCost { get; }
        IBookRepository Book { get; }
        IBookSizeRepository BookSize { get; }
        IBookTagRepository BookTag { get; }
        IPublisherRepository Publisher { get; }

        Task SaveAsync();
    }
}
