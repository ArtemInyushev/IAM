using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Enums;
using IAM.Core.Models;

namespace IAM.ClientApi.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<EntRole, EntRoleDto>();

            CreateMap<RoleType, RoleTypeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));
        }
    }
}
