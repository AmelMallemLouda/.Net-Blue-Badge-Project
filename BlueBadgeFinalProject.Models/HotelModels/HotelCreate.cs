using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.HotelModels
{
    public class HotelCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        public string Location { get; set; }
        [Required]
        public bool HasFreeParking { get; set; }

        
    }
}
