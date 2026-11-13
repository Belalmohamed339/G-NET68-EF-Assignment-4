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
    internal class Mangerconfigs : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Branch).WithOne(b => b.manager).HasForeignKey<Manager>(m => m.BranchID);
            builder.Property(m => m.FullName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(m => m.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(m => m.PhoneNumber).IsRequired().HasColumnType("varchar(15)");
            builder.Property(m => m.HireDate).IsRequired().HasColumnType("date");
        }
    }
}
