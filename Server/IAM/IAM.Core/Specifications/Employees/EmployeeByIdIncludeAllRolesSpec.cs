using Ardalis.Specification;
using IAM.Core.Enums;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeeByIdIncludeAllRolesSpec : EmployeesIncludeAllRolesSpec, ISingleResultSpecification<Employee>
    {
        public EmployeeByIdIncludeAllRolesSpec(long id, IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Where(e => e.Id == id);
        }
    }
}
