using Ardalis.Specification;
using IAM.Core.Enums;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Employees
{
    public class BaseEmployeeSpec : Specification<Employee>
    {
        public BaseEmployeeSpec(IsActive isActive = IsActive.Active)
        {
            switch (isActive)
            {
                case IsActive.Active:
                    Query.Where(e => e.IsActive == true);
                    break;
                case IsActive.NotActive:
                    Query.Where(e => e.IsActive == false);
                    break;
            }
        }
    }
}
