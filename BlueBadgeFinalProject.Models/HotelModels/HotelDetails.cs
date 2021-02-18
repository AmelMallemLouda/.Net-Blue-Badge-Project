using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelDetails
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public bool HasFreeParking { get; set; }

       // public string Package { get; set; } , what kind of package they Offer
    }
}
