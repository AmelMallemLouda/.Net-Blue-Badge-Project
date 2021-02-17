using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.TransactionModels
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public string CustomerName { get; set; }
        public string Price { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
