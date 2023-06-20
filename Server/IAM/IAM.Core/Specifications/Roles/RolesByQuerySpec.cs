using Ardalis.Specification;
using IAM.Core.Enums;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Roles
{
    public class RolesByQuerySpec : Specification<Role>
    {
        public RolesByQuerySpec(RoleType type, string query, int maxCount)
        {
            Query
                .Where(r => r.Type == type
                         && (r.Name.ToUpper().Contains(query.ToUpper())||
                             r.Description.ToUpper().Contains(query.ToUpper()))
                      )
                .Take(maxCount);
        }
    }
}
