using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.Models.DTOs
{
    public class BookDTO : BaseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Avatar { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a publisher")]
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select an author")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a book size")]
        public int? SizeId { get; set; }
        public Size? Size { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Range(0, 100)]
        public double Discount { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime? PublishedDate { get; set; }
        public IEnumerable<ImportDTO>? BookCosts { get; set; }
        [Required, MinLength(1)]
        public IEnumerable<TagDTO>? Tags { get; set; }
    }
}
