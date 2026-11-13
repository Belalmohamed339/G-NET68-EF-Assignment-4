using System;

namespace G_NET68_EF_Assignment_4.Models
{
    public class Account
    {
        public int AccountNumber { get; set; } 
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; } = null!;
        public DateTime OpeningDate { get; set; }
        public Branch? branch { get; set; }
        public int? BranchID { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }=new HashSet<CustomerAccount>();
        public ICollection<Transaction> transactions { get; set; }=new HashSet<Transaction>();

    }
}
