
using Ardalis.Specification;
using IAM.Core.Enums;

namespace IAM.Core.Specifications.Employees
{
    public class EmployeesByDepartmentIdSpec : BaseEmployeeSpec
    {
        public EmployeesByDepartmentIdSpec(long departmentId, IsActive isActive = IsActive.Active) : base(isActive)
        {
            Query.Include(e => e.Personal)
                 .Include(e => e.Staffing).ThenInclude(s => s.Department)
                 .Where(e => e.Staffing.DepartmentId == departmentId);
        }
    }
}
