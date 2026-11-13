using System;
using System.ComponentModel.DataAnnotations;

namespace G_NET68_EF_Assignment_4.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HireDate { get; set; }

        public int BranchID { get; set; }
        public Branch Branch { get; set; } 

    }
}
