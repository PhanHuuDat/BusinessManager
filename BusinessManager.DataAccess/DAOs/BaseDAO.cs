namespace BusinessManager.DataAccess.DAOs
{
    public abstract class BaseDAO
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
    }
}
