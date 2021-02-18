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
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string Price { get; set; }
        public string CustomerName { get; set; }
    }
}
