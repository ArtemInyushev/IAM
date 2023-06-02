using IAM.Core.Enums;

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
        public string Initiator { get; set; }
        public RoleStatus Status { get; set; }
    }
}
