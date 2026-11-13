using System;
using System.ComponentModel.DataAnnotations;

namespace G_NET68_EF_Assignment_4.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; } 
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = null!;
        public string? Note { get; set; }
        public Account Account { get; set; }
        public int AccountID { get; set; }  
    }
}
