using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Registration
    {
        public int Registrationid { get; set; }
        public string UserName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
