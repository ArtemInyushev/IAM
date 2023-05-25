using IAM.Core.Models;
using IAM.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IAM.Infrastructure.Data
{
    public class IamDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeHasDeltaRole> EmployeeHasDeltaRoles { get; set; }
        public virtual DbSet<EmployeeHasEntRole> EmployeeHasEntRoles { get; set; }
        public virtual DbSet<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public virtual DbSet<EntRole> EntRoles { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staffing> Staffings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\\\SQLEXPRESS;Initial Catalog=iam-db;Trusted_Connection=True");
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeHasDeltaRoleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeHasEntRoleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeHasRoleConfiguration());
            modelBuilder.ApplyConfiguration(new EntRoleConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StaffingConfiguration());
        }
    }
}
