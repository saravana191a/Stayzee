namespace StayZee.Application.DTOs.ResponseDTO
{
    public class HomepageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public decimal RatePerDay { get; set; }
        public string Features { get; set; } = string.Empty;
    }
}
