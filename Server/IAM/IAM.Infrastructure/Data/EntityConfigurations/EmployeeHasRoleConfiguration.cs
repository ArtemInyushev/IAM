using IAM.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class EmployeeHasRoleConfiguration : IEntityTypeConfiguration<EmployeeHasRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeHasRole> builder)
        {
            builder.HasKey(p => new { p.RoleId, p.EmployeeId });

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.EmployeeHasRoles)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.EmployeeHasRoles)
                .HasForeignKey(i => i.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.EntRole)
                .WithMany(p => p.EmployeeHasRoles)
                .HasForeignKey(i => i.EntRoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
