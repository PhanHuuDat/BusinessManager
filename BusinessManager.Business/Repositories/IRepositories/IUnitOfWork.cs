namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }
        IBookCostRepository Import { get; }
        IBookRepository Book { get; }
        IBookSizeRepository Size { get; }
        IBookTagRepository Tag { get; }
        IPublisherRepository Publisher { get; }

        Task SaveAsync();
    }
}
