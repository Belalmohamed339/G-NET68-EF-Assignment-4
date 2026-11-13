using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET68_EF_Assignment_4.Context
{
    internal class Appdbcontext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CC62RI3\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate = true");
        }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Account> Accounts { get; set; }
        public DbSet<Models.CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Models.Branch> Branches { get; set; }
        public DbSet<Models.Manager> Managers { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configs.CustomerAccountConfig());
            modelBuilder.ApplyConfiguration(new Configs.AccountConfigs());
            modelBuilder.ApplyConfiguration(new Configs.Branchconfigs());
            modelBuilder.ApplyConfiguration(new Configs.Mangerconfigs());
        }
    
    }
}
