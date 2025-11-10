using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Appilication.DTOs.RequestDTO
{
    public class BookingRequestDTO
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid HomeId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Range(1, 20, ErrorMessage = "Number of guests must be between 1 and 20.")]
        public int NumberOfGuests { get; set; } = 1;

        
        public decimal? TotalPrice { get; set; }

        
        public Guid? BookingStatusId { get; set; }
        public Guid? PaymentStatusId { get; set; }
    }
}
