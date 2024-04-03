using System;
using System.Collections.Generic;

namespace API_BoombaMarket.Models
{
    public partial class Order
    {
        

        public int? IdOrder { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }

     
    }
}
