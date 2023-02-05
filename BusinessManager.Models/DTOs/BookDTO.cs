using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.Models.DTOs
{
    public class BookDTO : BaseDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

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
        public int? BookSizeId { get; set; }
        public BookSize? BookSize { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public IEnumerable<BookCostDTO>? BookCosts { get; set; }
        public IEnumerable<BookTagDTO>? BookTags { get; set; }
    }
}
