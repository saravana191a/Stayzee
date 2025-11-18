using Microsoft.EntityFrameworkCore;
using StayZee.Appilication.Interfaces.IRepository;
using StayZee.Domain.Entities;
using StayZee.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        // Get booking by ID
        public async Task<Booking?> GetBookingByIdAsync(Guid bookingId)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Include(b => b.PaymentStatus)
                .Include(b => b.Payment)
                .Include(b => b.Invoice)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

       
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Include(b => b.PaymentStatus)
                .ToListAsync();
        }

       
        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteBookingAsync(Guid bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        
        public async Task<IEnumerable<Booking>> GetBookingsByCustomerIdAsync(Guid customerId)
        {
            return await _context.Bookings
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();
        }

       
        public async Task<IEnumerable<Booking>> GetBookingsByHomeIdAsync(Guid homeId)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.BookingStatus)
                .Where(b => b.HomeId == homeId)
                .ToListAsync();
        }

       
        public async Task<IEnumerable<Booking>> GetActiveBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Home)
                .Include(b => b.BookingStatus)
                .Where(b => b.BookingStatus.BookingStatusName == "Active")
                .ToListAsync();
        }
    }
}
