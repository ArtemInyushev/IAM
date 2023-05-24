using IAM.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.AccountName).HasMaxLength(100);

            builder.HasOne(p => p.Personal)
                .WithMany()
                .HasForeignKey(i => i.PersonalId);

            builder.HasOne(p => p.Staffing)
                .WithMany()
                .HasForeignKey(i => i.StaffingId);

            builder.HasMany(p => p.EmployeeHasDeltaRoles)
                .WithOne(p => p.Employee)
                .HasForeignKey(i => i.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.EmployeeHasEntRoles)
                .WithOne(p => p.Employee)
                .HasForeignKey(i => i.EntRoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.EmployeeHasRoles)
                .WithOne(p => p.Employee)
                .HasForeignKey(i => i.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
