using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject.Models.TransactionModels
{
    public class TransactionCreate
    {

        [Required]
        public double Price { get; set; }

        public DateTime DateOfTransaction { get; set; }
        public int CustomerId { get; set; }
    }
}
