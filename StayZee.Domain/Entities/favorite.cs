using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Domain.Entities
{
    public class favorite
    {
         public Guid id { get; set; }= Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
    }
}
