using Microsoft.EntityFrameworkCore;
using StayZee.Application.Interfaces;
using StayZee.Domain.Entities;
using StayZee.Infrastructure.Data;

namespace StayZee.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Booking?> GetByIdAsync(Guid bookingId)
        {
            return await _context.Bookings
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Include(b => b.PaymentStatus)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Include(b => b.PaymentStatus)
                .ToListAsync();
        }
    }

    public class BookingStatusRepository : IBookingStatusRepository
    {
        private readonly AppDbContext _context;

        public BookingStatusRepository(AppDbContext context) => _context = context;

        public async Task<BookingStatus?> GetByIdAsync(Guid id)
        {
            return await _context.BookingStatuses.FirstOrDefaultAsync(bs => bs.BookingStatusId == id);
        }
    }

    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private readonly AppDbContext _context;

        public PaymentStatusRepository(AppDbContext context) => _context = context;

        public async Task<PaymentStatus?> GetByIdAsync(Guid id)
        {
            return await _context.PaymentStatuses.FirstOrDefaultAsync(ps => ps.PaymentStatusId == id);
        }
    }
}
