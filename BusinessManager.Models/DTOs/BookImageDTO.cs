using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class BookImageDTO : BaseDTO
    {
        
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a book")]
        public int BookId { get; set; }

        public Book? Book { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
