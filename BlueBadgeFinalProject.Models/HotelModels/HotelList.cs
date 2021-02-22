using BlueBadgeFinalProject.Data;
using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.TransactionModels;
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
        public List<CustomerList> Customers { get; set; } = new List<CustomerList>();

    }
}
