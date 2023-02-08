using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class AuthorDTO : BaseDTO
    {
        public int? Id { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}
