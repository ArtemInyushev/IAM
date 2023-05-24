namespace IAM.Core.Models
{
    public class EntRole
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
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set;}

        public EntRole()
        {
            Roles = new HashSet<Role>();
            EmployeeHasEntRoles = new HashSet<EmployeeHasEntRole>();
            EmployeeHasRoles = new HashSet<EmployeeHasRole>();
        }
    }
}
