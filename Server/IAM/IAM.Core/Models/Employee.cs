namespace IAM.Core.Models
{
    public class Employee : BaseEntity
    {
        public long PersonalId { get; set; }
        public virtual Personal Personal { get; set; }
        public long StaffingId { get; set; }
        public virtual Staffing Staffing { get; set; }
        public virtual ICollection<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public virtual ICollection<EmployeeHasDeltaRole> EmployeeHasDeltaRoles { get; set; }
        public virtual ICollection<EmployeeHasEntRole> EmployeeHasEntRoles { get; set; }
        public string AccountName { get; set; }
        public bool IsActive { get; set; }

        public Employee()
        {
            EmployeeHasRoles = new HashSet<EmployeeHasRole>();
            EmployeeHasDeltaRoles = new HashSet<EmployeeHasDeltaRole>();
            EmployeeHasEntRoles = new HashSet<EmployeeHasEntRole>();
        }
    }
}
