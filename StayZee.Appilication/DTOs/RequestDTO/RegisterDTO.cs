using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Application.DTOs.RequestDTO
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NICOrPassport { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Customer"; // default
    }
}
