using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.TransactionModels
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }
        public string Price { get; set; }
        public string CustomerName { get; set; }
    }
}
