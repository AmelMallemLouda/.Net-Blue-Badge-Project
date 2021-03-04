using BlueBadgeFinalProject.Models.CustomerFolder;
using System.Collections.Generic;

namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelDetails
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public virtual List<VacationPackageListItem> VacationPackages { get; set; } = new List<VacationPackageListItem>();

       

    }
}
