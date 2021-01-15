using Data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.APIContext.Configurations
{
    public class CarsConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Cars", "dbo");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Frame).HasMaxLength(100);
            builder.Property(e => e.Model).HasMaxLength(50);
            builder.Property(e => e.Enrollment).HasMaxLength(7);
        }
    }
}
