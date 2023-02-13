using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.Models.DTOs
{
    public class BookCostDTO : BaseDTO
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTimeOffset ImportDate { get; set; }
    }
}
