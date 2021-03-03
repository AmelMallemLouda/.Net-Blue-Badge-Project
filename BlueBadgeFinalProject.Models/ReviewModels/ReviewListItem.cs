using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.ReviewModels
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset DateOfReview { get; set; }  
    }
}
