using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.ReviewModels
{
    public class ReviewCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        //[Required]
        //[Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10 (1 = worst hotel experience, 10 = best hotel experience).")]
        //[MaxLength(3, ErrorMessage = "There are too many characters in this field. Please enter a number between 1 and 10.")]
        public double Rating { get; set; }
        public int HotelId { get; set; }
    }
}
