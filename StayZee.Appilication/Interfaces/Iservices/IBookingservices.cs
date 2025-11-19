using StayZee.Application.DTOs;

namespace StayZee.Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request);
        Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync();
        Task<BookingResponseDto?> GetBookingByIdAsync(Guid bookingId);
    }
}
