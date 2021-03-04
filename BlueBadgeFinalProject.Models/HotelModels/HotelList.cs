using BlueBadgeFinalProject.Models.CustomerFolder;
using BlueBadgeFinalProject.Models.Review;
using System.Collections.Generic;


namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelList
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public List<CustomerList> Customers { get; set; } = new List<CustomerList>();
        public List<VacationPackageListItem> VacationPackages { get; set; } = new List<VacationPackageListItem>();
        public List<ReviewListItem> Reviews{ get; set; } = new List<ReviewListItem>();
    }
}
