using System;
using System.Collections.Generic;

namespace API_BoombaMarket.Models
{
    public partial class User
    {
        

        public int? IdUser { get; set; }
        public int? RoleId { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

       
    }
}
