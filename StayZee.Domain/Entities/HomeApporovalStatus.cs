using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Domain.Entities
{
    public class HomeApporovalStatus
    {

        [Key]
        public Guid HomeApprovalStatusId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public ICollection<Home> Homes { get; set; }
    }
}
