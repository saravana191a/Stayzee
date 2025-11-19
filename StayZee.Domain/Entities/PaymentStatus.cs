using System;
using System.Collections.Generic;

namespace StayZee.Domain.Entities
{
    public class PaymentStatus
    {
        public Guid PaymentStatusId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
