using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(p => p.Description).IsRequired().HasColumnType("VARCHAR(1000)");
            builder.Property(p => p.Image).IsRequired().HasColumnType("VARCHAR(100)");

            builder.ToTable("Products");

        }
    }
}
