using Microsoft.EntityFrameworkCore;
using StayZee.Application.DTOs;
using StayZee.Application.Interfaces;

using StayZee.Domain.Entities;

namespace StayZee.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IHomeRepository _homeRepo;
        private readonly IBookingStatusRepository _bookingStatusRepo;
        private readonly IPaymentStatusRepository _paymentStatusRepo;

        public BookingService(
            IBookingRepository bookingRepo,
            IHomeRepository homeRepo,
            IBookingStatusRepository bookingStatusRepo,
            IPaymentStatusRepository paymentStatusRepo)
        {
            _bookingRepo = bookingRepo;
            _homeRepo = homeRepo;
            _bookingStatusRepo = bookingStatusRepo;
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request)
        {
            // Load related data
            var home = await _homeRepo.GetByIdAsync(request.HomeId);
            if (home == null) throw new Exception("Home not found");

            var bookingStatus = await _bookingStatusRepo.GetByIdAsync(request.BookingStatusId);
            if (bookingStatus == null) throw new Exception("Booking status not found");

            var paymentStatus = await _paymentStatusRepo.GetByIdAsync(request.PaymentStatusId);
            if (paymentStatus == null) throw new Exception("Payment status not found");

            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                HomeId = request.HomeId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                TotalPrice = request.TotalPrice,
                BookingStatusId = request.BookingStatusId,
                PaymentStatusId = request.PaymentStatusId
            };

            await _bookingRepo.AddAsync(booking);

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                CustomerId = booking.CustomerId,
                HomeId = booking.HomeId,
                HomeName = home.Name,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                TotalPrice = booking.TotalPrice,
                BookingStatus = bookingStatus.BookingStatusName,
                PaymentStatus = paymentStatus.Name,
                CreatedAt = booking.CreatedAt
            };
        }

        public async Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepo.GetAllAsync();

            return bookings.Select(b => new BookingResponseDto
            {
                BookingId = b.BookingId,
                CustomerId = b.CustomerId,
                HomeId = b.HomeId,
                HomeName = b.Home?.Name,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                TotalPrice = b.TotalPrice,
                BookingStatus = b.BookingStatus?.BookingStatusName,
                PaymentStatus = b.PaymentStatus?.Name,
                CreatedAt = b.CreatedAt
            });
        }

        public async Task<BookingResponseDto?> GetBookingByIdAsync(Guid bookingId)
        {
            var b = await _bookingRepo.GetByIdAsync(bookingId);
            if (b == null) return null;

            return new BookingResponseDto
            {
                BookingId = b.BookingId,
                CustomerId = b.CustomerId,
                HomeId = b.HomeId,
                HomeName = b.Home?.Name,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                TotalPrice = b.TotalPrice,
                BookingStatus = b.BookingStatus?.BookingStatusName,
                PaymentStatus = b.PaymentStatus?.Name,
                CreatedAt = b.CreatedAt
            };
        }
    }
}
