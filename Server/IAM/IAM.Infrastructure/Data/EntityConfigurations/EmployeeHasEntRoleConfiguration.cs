using IAM.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class EmployeeHasEntRoleConfiguration : IEntityTypeConfiguration<EmployeeHasEntRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeHasEntRole> builder)
        {
            builder.HasKey(p => new { p.EntRoleId, p.EmployeeId });

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.EmployeeHasEntRoles)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.EntRole)
                .WithMany(p => p.EmployeeHasEntRoles)
                .HasForeignKey(i => i.EntRoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
