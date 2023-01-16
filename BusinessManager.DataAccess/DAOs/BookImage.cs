using System.ComponentModel.DataAnnotations;

namespace BusinessManager.DataAccess.DAOs
{
    public class BookImage : BaseDAO
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book? Book { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
