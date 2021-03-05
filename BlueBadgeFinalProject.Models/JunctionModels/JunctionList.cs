using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.HotelModels;
using BlueBadgeFinalProject.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.HotelCustomer
{
    public class JunctionList
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerList Customers { get; set; }

        public int HotelId { get; set; }
        public HotelList Hotels { get; set; }

        public int? ReviewId { get; set; }
        public ReviewListItem Review { get; set; }
    }
}
