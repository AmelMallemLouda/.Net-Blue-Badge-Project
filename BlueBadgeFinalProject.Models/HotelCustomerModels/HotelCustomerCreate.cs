using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.HotelCustomer
{
    public class HotelCustomerCreate
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int HotelId { get; set; }
    }
}
