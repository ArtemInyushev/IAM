using IAM.Core.Enums;

namespace IAM.ClientApi.Dtos
{
    public class RoleDto
    {
        public long Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType Type { get; set; }
    }
}
