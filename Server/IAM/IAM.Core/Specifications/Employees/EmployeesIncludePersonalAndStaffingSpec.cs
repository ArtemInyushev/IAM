using Ardalis.Specification;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesIncludePersonalAndStaffingSpec : BaseEmployeeSpec
    {
        public EmployeesIncludePersonalAndStaffingSpec(bool isActive = true) : base(isActive)
        {
            Query.Include(e => e.Personal)
                 .Include(e => e.Staffing);
        }
    }
}
