using StayZee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Appilication.Interfaces.IRepository
{
    public interface IBookingRepository
    {
        Task<Booking> AddBookingAsync(Booking booking);

        Task<Booking?> GetBookingByIdAsync(Guid bookingId);

       
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        
        Task UpdateBookingAsync(Booking booking);

        
        Task DeleteBookingAsync(Guid bookingId);

       
        Task<IEnumerable<Booking>> GetBookingsByCustomerIdAsync(Guid customerId);

        
        Task<IEnumerable<Booking>> GetBookingsByHomeIdAsync(Guid homeId);

        
        Task<IEnumerable<Booking>> GetActiveBookingsAsync();
    }
}
