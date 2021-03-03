﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.Review
{
    public class ReviewCreate
    {
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int CustomerId { get; set; }
       
        [Required]
        public string Text { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public DateTimeOffset DateOfReview { get; set; }
    }
}
