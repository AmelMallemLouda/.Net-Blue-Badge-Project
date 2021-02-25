using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models
{
    public class VacationPackageCreate
    {
        [Required]
        public string VacPacName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter an amount over 0.00")]
        public string Price { get; set; }
        [Required]
        public string Transportation { get; set; }
    }
}
