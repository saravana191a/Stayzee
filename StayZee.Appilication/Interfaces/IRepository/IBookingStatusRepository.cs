using StayZee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayZee.Application.Interfaces.IRepository
{
    public interface IBookingStatusRepository
    {
        Task<BookingStatus?> GetByIdAsync(Guid id);
        Task<BookingStatus?> GetByNameAsync(string name);
        Task<IEnumerable<BookingStatus>> GetAllAsync();
        Task AddAsync(BookingStatus bookingStatus);
    }
}
