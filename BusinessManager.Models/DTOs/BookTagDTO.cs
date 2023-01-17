using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class BookTagDTO : BaseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
