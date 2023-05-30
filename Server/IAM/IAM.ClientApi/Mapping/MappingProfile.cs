using AutoMapper;
using IAM.ClientApi.Dtos;
using IAM.Core.Models;

namespace IAM.ClientApi.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
