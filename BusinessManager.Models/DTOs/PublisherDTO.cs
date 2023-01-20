using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class PublisherDTO : BaseDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

    }
}
