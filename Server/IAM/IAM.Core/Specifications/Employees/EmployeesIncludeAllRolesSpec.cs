using Ardalis.Specification;
using IAM.Core.Enums;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeAllRolesSpec : EmployeesIncludeRolesSpec
    {
        public EmployeesIncludeAllRolesSpec(IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasEntRoles).ThenInclude(r => r.EntRole);
        }
    }
}
