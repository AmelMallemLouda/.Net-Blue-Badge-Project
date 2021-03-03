using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class VacationPackage
    {
        [Key]
        public int VacId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string VacationPackageName { get; set; }
        [Required]
        public string Flight { get; set; }
        [Required]
        public string Food { get; set; }
        [Required]
        public string Transportation { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [ForeignKey(nameof(Hotels))]
        public int HotelId { get; set; }
        public virtual Hotel Hotels { get; set; }    
    }
}
