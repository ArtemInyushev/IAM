namespace IAM.Core.Models
{
    public class Staffing : BaseEntity
    {
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<EntRole> EntRoles { get; set; }
        public int StaffingCode { get; set; }
        public string ProfessionName { get; set; }

        public Staffing()
        {
            Employees = new HashSet<Employee>();
            EntRoles = new HashSet<EntRole>();
        }
    }
}
