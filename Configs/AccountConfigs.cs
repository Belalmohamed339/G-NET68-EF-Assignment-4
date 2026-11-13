using G_NET68_EF_Assignment_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET68_EF_Assignment_4.Configs
{
    internal class AccountConfigs : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);
            builder.Property(a => a.CurrentBalance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.AccountType).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.OpeningDate).IsRequired().HasColumnType("date");
            builder.HasMany(t=>t.transactions).WithOne(a => a.Account).HasForeignKey(t => t.AccountID);
            builder.Property(a => a.AccountNumber).UseIdentityColumn(10, 10);
        }
    }
}
