using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.DataAccess.DAOs
{
    public class Import : BaseDAO
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime ImportDate { get; set; }
    }
}
