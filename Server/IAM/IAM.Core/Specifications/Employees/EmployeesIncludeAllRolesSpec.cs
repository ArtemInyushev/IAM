using Ardalis.Specification;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludeAllRolesSpec : EmployeesIncludeRolesSpec
    {
        public EmployeesIncludeAllRolesSpec(bool isActive = true) : base(isActive)
        {
            Query.Include(e => e.EmployeeHasEntRoles).ThenInclude(r => r.EntRole);
        }
    }
}
