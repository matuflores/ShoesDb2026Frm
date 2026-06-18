using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Configurations
{
    public class SportEntityTypeConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            //builder.ToTable("Sports");
            builder.HasKey(sp => sp.SportId);
            builder.Property(sp => sp.SportName).IsRequired().HasMaxLength(20);
            builder.HasIndex(sp => sp.SportName, "IX_Sports_SportName").IsUnique();
            builder.Property(sp => sp.RowVersion).IsRowVersion();
        }
    }
}
