using System;
using System.Collections.Generic;

namespace API_BoombaMarket.Models
{
    public partial class Feedback
    {
        public int? IdFeedback { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public string? Feedback1 { get; set; }

        
    }
}
