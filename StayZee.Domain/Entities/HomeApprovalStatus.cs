using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StayZee.Domain.Entities
{
    public class HomeApprovalStatus
    {
        [Key]
        public Guid HomeApprovalStatusId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Home> Homes { get; set; } = new List<Home>();
    }
}
