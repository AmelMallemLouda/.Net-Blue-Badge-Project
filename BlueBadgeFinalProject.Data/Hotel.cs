using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool HasFreeParking { get; set; }

       public virtual List<Customer> Customers{ get; set; }
       //public virtual List<Review> Reviews {get; set;}=new List<Review>();
        public virtual List<Transaction> Transactions {get; set;}= new List<Transaction>();
        public virtual List<VacationPackage>VacationPackages{get;set;}=new List <VacationPackage>();

    }
}
