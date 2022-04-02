using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(a => a.Number).IsRequired().HasColumnType("VARCHAR(10)");
            builder.Property(a => a.ZipCode).IsRequired().HasColumnType("VARCHAR(8)");
            builder.Property(a => a.Additional).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(a => a.Neighborhood).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(a => a.City).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(a => a.State).IsRequired().HasColumnType("VARCHAR(200)");
            builder.ToTable("Address");
        }
    }
}
