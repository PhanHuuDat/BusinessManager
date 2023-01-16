using System.ComponentModel.DataAnnotations;

namespace BusinessManager.DataAccess.DAOs
{
    public class Supplier : BaseDAO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }

    }
}
