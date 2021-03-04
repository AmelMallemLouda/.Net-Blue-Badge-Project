using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models
{
    public class VacationEdit
    {
        public int VacId { get; set; }
        public string VacationPackageName { get; set; }
        public bool Flight { get; set; }
        public bool Food { get; set; }
        public bool Transportation { get; set; }
        public string Price { get; set; }
        public int HotelId { get; set; }
    }
}
