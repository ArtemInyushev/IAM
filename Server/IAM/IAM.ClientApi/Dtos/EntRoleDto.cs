using IAM.Core.Models;

namespace IAM.ClientApi.Dtos
{
    public class EntRoleDto
    {
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long StaffingId { get; set; }
        public virtual Staffing Staffing { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<EmployeeHasEntRole> EmployeeHasEntRoles { get; set; }
        public virtual ICollection<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public string Initiator { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsInherited { get; set; }
    }
}
