using System;
using System.ComponentModel.DataAnnotations;

namespace G_NET68_EF_Assignment_4.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string NationalId { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CustomerType { get; set; } = null!;
        public ICollection<CustomerAccount> customerAccounts { get; set; } = new HashSet<CustomerAccount>();
    }
}