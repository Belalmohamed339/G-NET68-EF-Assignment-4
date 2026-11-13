using System;

namespace G_NET68_EF_Assignment_4.Models
{
    public class CustomerAccount
    {
        public string OwnershipType { get; set; } = null!;
        public DateTime OwnershipStartDate { get; set; }
        public string AccountStatus { get; set; } = null!;

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
