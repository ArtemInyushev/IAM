using Ardalis.Specification;
using IAM.Core.Models;

namespace IAM.Core.Specifications.Roles
{
    public class RolesByEnternalIdsSpec : Specification<Role>
    {
        public RolesByEnternalIdsSpec(IEnumerable<Guid> externalIds)
        {
            Query.Where(r => externalIds.Any(e => e == r.ExternalId));
        }
    }
}
