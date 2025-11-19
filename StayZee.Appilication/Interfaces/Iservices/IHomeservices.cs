using StayZee.Application.DTOs;

namespace StayZee.Application.Interfaces
{
    public interface IHomeService
    {
        Task<HomeResponseDto> CreateHomeAsync(HomeRequestDto request);
        Task<HomeResponseDto?> GetHomeByIdAsync(Guid id);
        Task<IEnumerable<HomeResponseDto>> GetAllHomesAsync();
    }
}
