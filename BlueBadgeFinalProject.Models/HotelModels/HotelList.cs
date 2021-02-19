using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models.CustomerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelList
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<CustomerList> Customers { get; set; }

    }
}
