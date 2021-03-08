using BlueBadgeFinalProject.Models.CustomerFolder;
using System.Collections.Generic;


namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelList
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public List<VacationPackageListItem> VacationPackages { get; set; } = new List<VacationPackageListItem>();
        
    }
}
