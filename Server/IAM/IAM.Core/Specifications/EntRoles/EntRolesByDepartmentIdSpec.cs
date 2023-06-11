using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.EntRoles
{
    public class EntRolesByDepartmentIdSpec : Specification<EntRole>
    {
        public EntRolesByDepartmentIdSpec(long departmentId)
        {
            Query.Include(e => e.Department)
                 .Include(e => e.Staffing)
                 .Include(e => e.Roles)
                 .Where(e => e.DepartmentId == departmentId);
        }
    }
}
