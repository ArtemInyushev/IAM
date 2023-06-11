using IAM.Core.Models;

namespace IAM.ClientApi.Dtos
{
    internal class StaffingDto
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EntRole> EntRoles { get; set; }
        public string EntRoleCode 
        { 
            get
            {
                return EntRoles.FirstOrDefault()?.Code;
            } 
        }
        public int StaffingCode { get; set; }
        public string ProfessionName { get; set; }
    }
}
