using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Appilication.DTOs.ResponseDTO
{
    public class BookingResponseDTO
    {
        public Guid BookingId { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public Guid HomeId { get; set; }
        public string HomeTitle { get; set; } = string.Empty;
        public string HomeAddress { get; set; } = string.Empty;

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Nights => (CheckOutDate > CheckInDate)
            ? (CheckOutDate.Date - CheckInDate.Date).Days
            : 0;

        public decimal TotalPrice { get; set; }

        public Guid BookingStatusId { get; set; }
        public string BookingStatusName { get; set; } = string.Empty;

        public Guid PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public PaymentResponsesDTO? Payment { get; set; }
        public InvoiceResponsesDTO? Invoice { get; set; }
    }

    public class PaymentResponsesDTO
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaidAt { get; set; }
        public string TransactionId { get; set; } = string.Empty;
    }

    public class InvoiceResponsesDTO
    {
        public Guid InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime IssuedAt { get; set; }
        public string PdfUrl { get; set; } = string.Empty;
    }
}
