using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET68_EF_Assignment_4.Configs
{
    internal class CustomerAccountConfig:IEntityTypeConfiguration<Models.CustomerAccount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Models.CustomerAccount> builder)
        {
            builder.HasKey(ca => new { ca.CustomerId, ca.AccountId });

            builder.Property(ca => ca.OwnershipType).IsRequired().HasColumnType("varchar(50)");

            builder.Property(ca => ca.OwnershipStartDate).IsRequired().HasColumnType("date");

            builder.Property(ca => ca.AccountStatus).IsRequired().HasColumnType("varchar(20)");
            builder.HasOne(ca => ca.Customer)
                .WithMany(c => c.customerAccounts)
                .HasForeignKey(ca => ca.CustomerId);

            builder.HasOne(ca => ca.Account)
                .WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountId);
        }
    }
    
    }

