using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public string CustomerName { get; set; }

        [Required]
        public DateTime DateOfTransaction { get; set; }

        [Required]
        public string Price { get; set; } 

        [Required]
        public Guid OwnerId {get; set;}

        /*[ForeignKey (nameof(Hotel))]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
         */

        /*[ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }*/
    }
}
