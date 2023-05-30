using IAM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class StaffingConfiguration : IEntityTypeConfiguration<Staffing>
    {
        public void Configure(EntityTypeBuilder<Staffing> builder)
        {
            builder.Property(p => p.ProfessionName).HasMaxLength(50);

            builder.HasIndex(p => p.StaffingCode).IsUnique();

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
