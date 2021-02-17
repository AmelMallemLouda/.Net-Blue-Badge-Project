using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class VacationPackage
    {
        [Key]
        public int VacId { get; set; }

        public string Flight { get; set; }
        public string Food { get; set; }
        public string Transportation { get; set; }
        public double Price { get; set; }

    }
}
