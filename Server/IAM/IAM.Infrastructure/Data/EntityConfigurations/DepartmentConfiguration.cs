using IAM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Data.EntityConfigurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(p => p.DepartmentCode).HasMaxLength(50);
            builder.Property(p => p.FullName).HasMaxLength(250);

            builder.HasOne(p => p.ParentDepartment)
                .WithMany()
                .HasForeignKey(i => i.ParentId)
                .OnDelete(DeleteBehavior.NoAction); ;
        }
    }
}
