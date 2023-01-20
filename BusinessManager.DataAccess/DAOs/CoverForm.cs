using System.ComponentModel.DataAnnotations;

namespace BusinessManager.DataAccess.DAOs
{
    public class CoverForm : BaseDAO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CoverName { get; set; } = string.Empty;

        [StringLength(200)]
        public string CoverDescription { get; set;} = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
