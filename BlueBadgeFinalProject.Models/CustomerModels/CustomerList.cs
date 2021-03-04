using BlueBadgeFinalProject.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.CustomerFolder
{
    public class CustomerList
    {
        public int CustomerId { get; set; }
        public  string FullName { get; set; }
         public virtual List<TransactionListItem> Transactions { get; set; } = new List<TransactionListItem>();
        //public virtual TransactionListItem Transaction { get; set; } = new TransactionListItem();

    }
}
