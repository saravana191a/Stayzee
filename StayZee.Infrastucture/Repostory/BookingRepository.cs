using StayZee.Appilication.Interfaces.IRepository;
using StayZee.Domain.Entities;
using StayZee.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Infrastucture.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookingRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

       
        public void AddBooking(Booking booking)
        {
            _appDbContext.Bookings.Add(booking);
            _appDbContext.SaveChanges();
        }

        
        public List<Booking> GetAllBookings()
        {
            return _appDbContext.Bookings
                .ToList();
        }

       
        public Booking? GetBookingById(Guid id)
        {
            return _appDbContext.Bookings
                .FirstOrDefault(b => b.BookingId == id);
        }

       
        public void UpdateBooking(Booking booking)
        {
            _appDbContext.Bookings.Update(booking);
            _appDbContext.SaveChanges();
        }

        public void DeleteBooking(Guid id)
        {
            var booking = _appDbContext.Bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking != null)
            {
                _appDbContext.Bookings.Remove(booking);
                _appDbContext.SaveChanges();
            }
        }

    }
}
