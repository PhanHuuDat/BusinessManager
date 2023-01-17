namespace BusinessManager.Business.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }
        IBookCostRepository BookCost { get; }
        IBookImageRepository BookImage { get; }
        IBookRepository Book { get; }
        IBookSizeRepository BookSize { get; }
        IBookTagRepository BookTag { get; }
        ICoverFormRepository CoverForm { get; }
        IPublisherRepository Publisher { get; }
    }
}
