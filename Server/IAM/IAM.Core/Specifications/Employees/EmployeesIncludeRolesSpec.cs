using Ardalis.Specification;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeRolesSpec : BaseEmployeeSpec
    {
        public EmployeesIncludeRolesSpec(bool isActive = true) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasRoles).ThenInclude(r => r.Role);
        }
    }
}
