namespace BusinessManager.DataAccess.DAOs
{
    public class BookCost : BaseDAO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset ImportDate { get; set; }
    }
}
