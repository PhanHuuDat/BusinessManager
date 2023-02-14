using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.DataAccess.DAOs
{
    public class Book : BaseDAO
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

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<Import>? Costs { get; set; }
       
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
