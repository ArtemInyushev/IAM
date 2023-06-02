using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Employees
{
    public class BaseEmployeeSpec : Specification<Employee>
    {
        public BaseEmployeeSpec(bool isActive = true)
        {
            Query.Where(e => e.IsActive == isActive);
        }
    }
}
