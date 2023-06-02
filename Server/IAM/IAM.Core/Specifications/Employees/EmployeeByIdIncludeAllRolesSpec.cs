using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeeByIdIncludeAllRolesSpec : EmployeesIncludeAllRolesSpec, ISingleResultSpecification<Employee>
    {
        public EmployeeByIdIncludeAllRolesSpec(long id, bool isActive = true) : base(isActive)
        {
            Query.Where(e => e.Id == id);
        }
    }
}
