﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.ReviewModles
{
    public class ReviewCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }
        public double Rating { get; set; }
      
    }
}
