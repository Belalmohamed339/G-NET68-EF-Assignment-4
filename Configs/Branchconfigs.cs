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
    internal class Branchconfigs : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);
            builder.Property(b => b.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(b => b.Address).IsRequired().HasColumnType("varchar(200)");
            builder.Property(b => b.PhoneNumber).IsRequired().HasColumnType("varchar(15)");
            builder.HasMany(b => b.Accounts).WithOne(a => a.branch).HasForeignKey(a => a.BranchID);

        }
    }
}
