using Ardalis.Specification;
using IAM.Core.Enums;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeRolesSpec : BaseEmployeeSpec
    {
        public EmployeesIncludeRolesSpec(IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasRoles).ThenInclude(r => r.Role);
        }
    }
}
