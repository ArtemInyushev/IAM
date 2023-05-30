using IAM.Core.Enums;

namespace IAM.Core.Models
{
    public class Role : BaseEntity
    {
        public virtual ICollection<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public virtual ICollection<EmployeeHasDeltaRole> EmployeeHasDeltaRoles { get; set; }
        public virtual ICollection<EntRole> EntRoles { get; set; }
        public Guid ExternaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeRole Type { get; set; }

        public Role()
        {
            EmployeeHasRoles = new HashSet<EmployeeHasRole>();
            EmployeeHasDeltaRoles = new HashSet<EmployeeHasDeltaRole>();
            EntRoles = new HashSet<EntRole>();
        }
    }
}
