using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.Review
{
   public class ReviewListItem
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerList Customers { get; set; }

        public int HotelId { get; set; }
        public HotelList Hotels { get; set; }
    }
}
