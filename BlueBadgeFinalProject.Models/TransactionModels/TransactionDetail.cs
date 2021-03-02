using BlueBadgeFinalProject.Models.CustomerFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.TransactionModels
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
       
        public double Price { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset DateOfTransaction { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        
        public int CustomerId { get; set; }



    }
}
