﻿using System;
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
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Customers))]
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }

       

        [Key, Column(Order =1)]
        [ForeignKey(nameof(Hotels))]
        public int HotelId { get; set; }
        public virtual Hotel Hotels { get; set; }
    }
}
