namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }
        IImportRepository Import { get; }
        IBookRepository Book { get; }
        IBookSizeRepository Size { get; }
        IBookTagRepository Tag { get; }
        IPublisherRepository Publisher { get; }

        Task SaveAsync();
    }
}
