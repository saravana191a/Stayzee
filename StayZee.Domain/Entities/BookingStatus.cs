using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StayZee.Domain.Entities
{
    public class BookingStatus
    {
        [Key]
        public Guid BookingStatusId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string BookingStatusName { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
