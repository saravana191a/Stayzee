using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Domain.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string AccountNumber { get; set; }
        public string HomeLocation { get; set; }
        public decimal OneDayPrice { get; set; }
        public decimal CurrentBill { get; set; }

        public string PhotoUrl1 { get; set; }
        public string PhotoUrl2 { get; set; }
        public string PhotoUrl3 { get; set; }
        public string PhotoUrl4 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
