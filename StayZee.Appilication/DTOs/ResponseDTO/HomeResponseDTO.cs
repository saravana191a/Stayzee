namespace StayZee.Application.DTOs
{
    public class HomeResponseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public decimal RatePerDay { get; set; }
    }
}
