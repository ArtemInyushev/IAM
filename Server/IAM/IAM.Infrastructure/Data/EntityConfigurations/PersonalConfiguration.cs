﻿using IAM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.FatherName).HasMaxLength(50);
            builder.Property(p => p.INN).HasMaxLength(15);

            builder.Ignore(p => p.FullName);
        }
    }
}
