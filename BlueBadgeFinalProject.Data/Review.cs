using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public DateTimeOffset DateOfReview { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        //[Required]
        //[ForeignKey(nameof(Hotels))]
        //public int HotelId { get; set; }
        //public virtual Hotel Hotels { get; set; }
    }
}
