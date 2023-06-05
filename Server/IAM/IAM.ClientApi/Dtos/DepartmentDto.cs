using AutoMapper;
using IAM.Core.Models;

namespace IAM.ClientApi.Dtos
{
    internal static class DepartmentDtoExtensions
    {
        public static IEnumerable<DepartmentDto> GenerateTree(this IEnumerable<Department> departments, 
            IMapper mapper, 
            long? departmentId = null)
        {
            var departmentsHead = new List<DepartmentDto>();
            foreach(var department in departments.Where(d => d.ParentId == departmentId))
            {
                var departmentDto = mapper.Map<DepartmentDto>(department);
                departmentDto.AddChildren(departments.GenerateTree(mapper, department.Id));
                departmentsHead.Add(departmentDto);
            }
            return departmentsHead;
        }
    }

    internal class DepartmentDto
    {
        public long Id { get; set; }
        public int DepartmentCode { get; set; }
        public string FullName { get; set; }
        public long ParentId { get; set; }
        public List<DepartmentDto> ChildDepartments { get; }

        public DepartmentDto()
        {
            ChildDepartments = new List<DepartmentDto>();
        }

        public void AddChildren(IEnumerable<DepartmentDto> departments)
        {
            ChildDepartments.AddRange(departments);
        }
    }
}
