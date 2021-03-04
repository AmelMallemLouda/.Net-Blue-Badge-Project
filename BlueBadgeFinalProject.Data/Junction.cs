using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class Junction
    {
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }
    }
}
