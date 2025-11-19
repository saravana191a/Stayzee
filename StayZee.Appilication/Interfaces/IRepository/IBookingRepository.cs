using StayZee.Domain.Entities;

namespace StayZee.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task<Booking?> GetByIdAsync(Guid bookingId);
        Task<IEnumerable<Booking>> GetAllAsync();
    }

    public interface IBookingStatusRepository
    {
        Task<BookingStatus?> GetByIdAsync(Guid id);
    }

    public interface IPaymentStatusRepository
    {
        Task<PaymentStatus?> GetByIdAsync(Guid id);
    }
}
