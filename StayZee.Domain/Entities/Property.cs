using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string title { get; set; } = " ";
        public string Title { get; set; }
        public string description { get; set; } = " ";
        public string Description { get; set; }
        public string City { get; set; } = " ";
        public int MiniBedrooms { get; set; } = 1;
        public decimal DayPrice { get; set; } 
        public bool IsFurnished { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool HasWifi { get; set; }
        public bool HasParking { get; set; }
        public string PropertyType { get; set; } = " ";
        public bool IsLongTerm { get; set; }= true;
        public string ImageUrl { get; set; }=" ";
        public int MinBedrooms { get; set; }
    }
}
