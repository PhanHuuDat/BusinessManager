namespace BusinessManager.DataAccess.DAOs
{
    public abstract class BaseDAO
    {
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
