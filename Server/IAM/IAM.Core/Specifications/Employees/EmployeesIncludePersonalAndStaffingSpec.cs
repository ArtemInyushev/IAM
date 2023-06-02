using Ardalis.Specification;
using IAM.Core.Enums;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludePersonalAndStaffingSpec : BaseEmployeeSpec
    {
        public EmployeesIncludePersonalAndStaffingSpec(IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Include(e => e.Personal)
                 .Include(e => e.Staffing);
        }
    }
}
