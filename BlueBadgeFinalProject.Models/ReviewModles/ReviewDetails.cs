using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.ReviewModles
{
    public class ReviewDetails
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset DateOfReview { get; set; }
      
    }
}
