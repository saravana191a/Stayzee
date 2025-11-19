using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StayZee.Domain.Entities
{
    public class Home
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        [Required]
        [MaxLength(500)]
        public string Features { get; set; } = string.Empty;

        [Required]
        public decimal RatePerDay { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid HomeApprovalStatusId { get; set; }
        public HomeApprovalStatus? HomeApprovalStatus { get; set; }

        // Navigation Properties
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<HomeDocument> Documents { get; set; } = new List<HomeDocument>();
    }
}
