using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.DataAccess.DAOs
{
    public class Book : BaseDAO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        [ForeignKey("BookSize")]
        public int BookSizeId { get; set; }
        public BookSize? BookSize { get; set; }

        [ForeignKey("CoverForm")]
        public int CoverFormId { get; set; }
        public CoverForm? CoverForm { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public ICollection<BookCost>? BookCosts { get; set; }
        public ICollection<BookTag>? BookTags { get; set; }

    }
}
