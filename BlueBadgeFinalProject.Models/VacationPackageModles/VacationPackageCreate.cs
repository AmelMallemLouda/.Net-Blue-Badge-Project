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
      
        public string VacPacName { get; set; }
      
        public double Price { get; set; }
     
        public string Transportation { get; set; }
       
        public string Flight { get; set; }
        public string Food { get; set; }
        public int HotelId { get; set; }
    }
}
