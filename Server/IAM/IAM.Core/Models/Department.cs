namespace IAM.Core.Models 
{
    public class Department : BaseEntity
    {
        public long? ParentId { get; set; }
        public Department ParentDepartment { get; set; }
        public string DepartmentCode { get; set; }
        public string FullName { get; set; }
    }
}
