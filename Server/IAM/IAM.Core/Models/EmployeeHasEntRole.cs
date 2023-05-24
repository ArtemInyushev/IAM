namespace IAM.Core.Models
{
    public class EmployeeHasEntRole
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long EntRoleId { get; set; }
        public virtual EntRole EntRole { get; set; }
        public DateTime DateStart { get; set; } = DateTime.UtcNow;
        public DateTime? DateEnd { get; set; }
    }
}
