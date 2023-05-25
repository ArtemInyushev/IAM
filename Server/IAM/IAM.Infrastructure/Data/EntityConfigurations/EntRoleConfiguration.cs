using IAM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class EntRoleConfiguration : IEntityTypeConfiguration<EntRole>
    {
        public void Configure(EntityTypeBuilder<EntRole> builder)
        {
            builder.Property(p => p.Initiator).HasMaxLength(100);
            builder.Property(p => p.Code).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(300);

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Staffing)
               .WithMany(p => p.EntRoles)
               .HasForeignKey(i => i.StaffingId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Roles)
                .WithMany(p => p.EntRoles)
                .UsingEntity<Dictionary<long, long>>
                (
                    "EntRoleHasRole",
                    i => i.HasOne<Role>().WithMany().OnDelete(DeleteBehavior.Restrict),
                    i => i.HasOne<EntRole>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );
        }
    }
}
