using IAM.Core.Models;

namespace IAM.ClientApi.Dtos
{
    internal class EmployeeDto
    {
        public long Id { get; set; }
        public long PersonalId { get; set; }
        public Personal Personal { get; set; }
        public string PersonalDisplayName { get; set; }
        public long StaffingId { get; set; }
        public Staffing Staffing { get; set; }
        public string StaffingStaffingCode { get; set; }
        public string StaffingProfessionName { get; set; }
        public string StaffingDepartmentFullName { get; set; }
        public ICollection<EmployeeHasRole> EmployeeHasRoles { get; set; }
        public ICollection<EmployeeHasEntRole> EmployeeHasEntRoles { get; set; }
        public long EmployeeIdentifier { get; set; }
        public string AccountName { get; set; }
        public bool IsActive { get; set; }
    }
}
