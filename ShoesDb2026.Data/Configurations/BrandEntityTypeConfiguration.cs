using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Configurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(b => b.BrandId);
            builder.Property(b=> b.BrandName).IsRequired().HasMaxLength(50);

            //builder.HasIndex(b => b.BrandName, "IX_Brands_BrandName").IsUnique();

            builder.Property(b => b.RowVersion).IsRowVersion();
        }
    }
}
