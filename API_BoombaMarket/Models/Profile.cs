using System;
using System.Collections.Generic;

namespace API_BoombaMarket.Models
{
    public partial class Profile
    {
        public int? IdProfile { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? PhoneNumber { get; set; } 
        public DateTime? BirthDate { get; set; }

    }
}
