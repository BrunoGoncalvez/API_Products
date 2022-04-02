using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Data.Mappings
{
    class ProviderMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("VARCHAR(200)");
            builder.Property(p => p.Identification).IsRequired().HasColumnType("VARCHAR(14)");
            builder.HasOne(p => p.Address).WithOne(a => a.Provider); // 1 : 1
            builder.HasMany(p => p.Products).WithOne(p => p.Provider).HasForeignKey(p => p.ProviderId);
            builder.ToTable("Providers");
        }
    }
}
