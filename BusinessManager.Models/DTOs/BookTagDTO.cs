using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Models.DTOs
{
    public class BookTagDTO : BaseDTO
    {
        public int? Id { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        public override bool Equals(object o)
        {
            var other = o as BookTagDTO;
            return other?.Name == Name;
        }

        // Note: this is important too!
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        // Implement this for the Pizza to display correctly in MudSelect
        public override string ToString() => Name;

    }
}
