using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.CustomerFolder
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool HasMemberShip { get; set; }
        public int HotelId { get; set; }
  
    }
}
