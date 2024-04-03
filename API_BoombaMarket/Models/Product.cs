using System;
using System.Collections.Generic;

namespace API_BoombaMarket.Models
{
    public partial class Product
    {
        

        public int? IdProduct { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Sale { get; set; }

        public Category? Category { get; set; }
        
    }
}
