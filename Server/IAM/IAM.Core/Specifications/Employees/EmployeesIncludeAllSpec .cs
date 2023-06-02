using Ardalis.Specification;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeAllSpec : EmployeesIncludePersonalAndStaffingSpec
    {
        public EmployeesIncludeAllSpec(bool isActive = true) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasEntRoles).ThenInclude(r => r.EntRole)
                 .Include(e => e.EmployeeHasRoles).ThenInclude(r => r.Role)
                 .AsSplitQuery();
        }
    }
}
