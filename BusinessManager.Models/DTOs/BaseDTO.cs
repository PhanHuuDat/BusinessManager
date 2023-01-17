namespace BusinessManager.Models.DTOs
{
    public abstract class BaseDTO
    {
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
