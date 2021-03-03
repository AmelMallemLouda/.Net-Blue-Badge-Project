using BlueBadgeFinalProject.Models.CustomerFolder;
using System.Collections.Generic;

namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelDetails
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public bool HasFreeParking { get; set; }
        public virtual List<CustomerList> Customers { get; set; } = new List<CustomerList>();
        public virtual List<VacationPackageListItem> VacationPackages { get; set; } = new List<VacationPackageListItem>();
       // public List<ReviewListItem> Reviews { get; set; } = new List<ReviewListItem>();

    }
}
