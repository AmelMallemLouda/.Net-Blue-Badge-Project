using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.HotelModels
{
   public  class HotelEdit
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool HasFreeParking { get; set; }
       // public string Package { get; set; }
    }
}
