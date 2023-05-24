namespace IAM.Core.Models
{
    public class EmployeeHasRole
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        public long? EntRoleId { get; set; }
        public virtual EntRole EntRole { get; set; }
        public DateTime DateStart { get; set; } = DateTime.UtcNow;
        public DateTime? DateEnd { get; set; }
    }
}
