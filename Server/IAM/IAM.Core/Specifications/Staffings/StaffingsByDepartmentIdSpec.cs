using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Staffings
{
    public class StaffingsByDepartmentIdSpec : Specification<Staffing>
    {
        public StaffingsByDepartmentIdSpec(long departmentId)
        {
            Query.Include(s => s.EntRoles)
                 .Include(s => s.Department)
                 .Where(s => s.DepartmentId == departmentId);
        }
    }
}
