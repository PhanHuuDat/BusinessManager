using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class PublisherDTO : BaseDTO
    {

        public int? Id { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; } = string.Empty;

    }
}
