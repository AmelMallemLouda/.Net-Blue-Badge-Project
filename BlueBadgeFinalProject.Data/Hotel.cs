using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual List<VacationPackage>VacationPackages{get;set;}=new List <VacationPackage>();

    }
}
