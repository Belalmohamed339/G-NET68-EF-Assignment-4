namespace G_NET68_EF_Assignment_4.Models
{
    public class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Manager manager { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
