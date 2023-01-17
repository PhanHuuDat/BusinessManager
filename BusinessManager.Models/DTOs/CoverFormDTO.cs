using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class CoverFormDTO : BaseDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string CoverName { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string CoverDescription { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
