using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class BookSizeDTO : BaseDTO
    {
        public int? Id { get; set; } = 0;
        [Required]
        [StringLength(20)]
        public string SizeValue { get; set; } = string.Empty;

    }
}
