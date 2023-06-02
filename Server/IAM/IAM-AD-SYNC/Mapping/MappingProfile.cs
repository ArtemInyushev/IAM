using AutoMapper;
using IAM.Core.Models;
using Microsoft.Graph.Models;

namespace IAM_AD_SYNC.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, Role>()
                .ForMember(x => x.Id, s => s.Ignore())
                .ForMember(x => x.ExternaId, s => s.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.DisplayName));

            CreateMap<User, Personal>()
                .ForMember(x => x.Id, s => s.Ignore())
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.GivenName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.Surname));

            CreateMap<User, Employee>()
                .ForMember(x => x.Id, s => s.Ignore())
                .ForMember(x => x.EmployeeIdentifier, s => s.MapFrom(x => long.Parse(x.EmployeeId)))
                .ForMember(x => x.AccountName, s => s.MapFrom(x => x.MailNickname))
                .ForMember(x => x.IsActive, s => s.MapFrom(x => x.AccountEnabled));
        }
    }
}
