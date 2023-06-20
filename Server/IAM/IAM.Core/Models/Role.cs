using IAM.Core.Enums;

namespace IAM.Core.Models
{
    public class Role : BaseEntity
    {
        public virtual ICollection<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public virtual ICollection<EntRole> EntRoles { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType Type { get; set; }

        public Role()
        {
            EmployeeHasRoles = new HashSet<EmployeeHasRole>();
            EntRoles = new HashSet<EntRole>();
        }
    }
}
