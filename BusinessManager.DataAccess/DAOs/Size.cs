using System.ComponentModel.DataAnnotations;

namespace BusinessManager.DataAccess.DAOs
{
    public class Size : BaseDAO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string SizeValue { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; } 
    }
}
