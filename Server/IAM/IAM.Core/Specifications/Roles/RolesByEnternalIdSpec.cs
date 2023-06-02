using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Roles
{
    public class RolesByEnternalIdSpec : Specification<Role>
    {
        public RolesByEnternalIdSpec(Guid externalId)
        {
            Query.Where(r => r.ExternaId == externalId);
        }
    }
}
