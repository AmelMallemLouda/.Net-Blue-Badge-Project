using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.CustomerFolder
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool HasMemberShip { get; set; }
        public int HotelId { get; set; }
        public virtual List<TransactionListItem> Transactions { get; set; } = new List<TransactionListItem>();


        //Public virtual List <Review> Reviews {get; set;}
    }
}
