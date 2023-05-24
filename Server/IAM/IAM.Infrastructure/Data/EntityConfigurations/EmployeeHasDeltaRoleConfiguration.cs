using IAM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class EmployeeHasDeltaRoleConfiguration : IEntityTypeConfiguration<EmployeeHasDeltaRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeHasDeltaRole> builder)
        {
            builder.HasKey(p => new { p.RoleId, p.EmployeeId });

            builder.Property(p => p.Initiator).HasMaxLength(100);

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.EmployeeHasDeltaRoles)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.EmployeeHasDeltaRoles)
                .HasForeignKey(i => i.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
