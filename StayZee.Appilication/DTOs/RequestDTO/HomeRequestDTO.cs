namespace StayZee.Application.DTOs
{
    public class HomeRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public string Features { get; set; } = string.Empty;
        public decimal RatePerDay { get; set; }
        public Guid OwnerId { get; set; }
    }
}
