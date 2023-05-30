using IAM.Core.Interfaces;
using IAM.Core.Models;

namespace IAM.Infrastructure.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IRepository<Department> _departmentsRepository;
        private readonly IRepository<Staffing> _staffingsRepository;

        public DataSeeder(IRepository<Department> departmentsRepository,
                          IRepository<Staffing> staffingsRepository)
        {
            _departmentsRepository = departmentsRepository;
            _staffingsRepository = staffingsRepository;
        }

        public async Task SeedData()
        {
            var departments = await _departmentsRepository.ListAsync();
            if (departments.Any()) return;

            #region Create departments
            var headDepartment = new Department
            {
                ParentId = null,
                DepartmentCode = 1001,
                FullName = "Експертна компанія",
            };

            var financialDepartment = new Department
            {
                ParentDepartment = headDepartment,
                DepartmentCode = 1002,
                FullName = "Фінансова дирекція",
            };

            var ITDepartment = new Department
            {
                ParentDepartment = headDepartment,
                DepartmentCode = 1003,
                FullName = "Дирекція розробки та впроваждення",
            };

            var projectManagingDepartment = new Department
            {
                ParentDepartment = ITDepartment,
                DepartmentCode = 1004,
                FullName = "Відділ управління проектами",
            };

            var developmentDepartment = new Department
            {
                ParentDepartment = ITDepartment,
                DepartmentCode = 1005,
                FullName = "Відділ розробки",
            };

            var analyticsDepartment = new Department
            {
                ParentDepartment = ITDepartment,
                DepartmentCode = 1006,
                FullName = "Відділ бізнес-аналітики",
            };

            var newDepartments = new List<Department>
            {
                headDepartment,
                financialDepartment,
                ITDepartment,
                projectManagingDepartment,
                developmentDepartment,
                analyticsDepartment
            };

            await _departmentsRepository.AddRangeAsync(newDepartments);
            #endregion

            #region Create Staffings
            var ceoStaffing = new Staffing
            {
                Department = headDepartment,
                StaffingCode = 101,
                ProfessionName = "Генеральний директор",
            };

            var ceoAssistantStaffing = new Staffing
            {
                Department = headDepartment,
                StaffingCode = 102,
                ProfessionName = "Помічник генерального директора",
            };

            var headAccountantStaffing = new Staffing
            {
                Department = financialDepartment,
                StaffingCode = 111,
                ProfessionName = "Головний бухгалтер",
            };

            var accountantStaffing = new Staffing
            {
                Department = financialDepartment,
                StaffingCode = 112,
                ProfessionName = "Бухгалтер",
            };

            var headOfITStaffing = new Staffing
            {
                Department = ITDepartment,
                StaffingCode = 201,
                ProfessionName = "Директор з розробки та впровадження",
            };

            var headProjectManagerStaffing = new Staffing
            {
                Department = projectManagingDepartment,
                StaffingCode = 211,
                ProfessionName = "Директор з управління проектами",
            };

            var projectManagerStaffing = new Staffing
            {
                Department = projectManagingDepartment,
                StaffingCode = 212,
                ProfessionName = "Менеджер проекта",
            };

            var headOfDevelopmentStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 221,
                ProfessionName = "Голова відділу розробки"
            };

            var teamLeadStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 222,
                ProfessionName = "Керівник команди"
            };

            var netDevStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 223,
                ProfessionName = ".Net розробник"
            };

            var javaDevStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 224,
                ProfessionName = "Java розробник"
            };

            var frontendDevStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 225,
                ProfessionName = "Фронтенд розробник"
            };

            var devopsStaffing = new Staffing
            {
                Department = developmentDepartment,
                StaffingCode = 226,
                ProfessionName = "Devops"
            };

            var headOfAnalyticsStaffing = new Staffing
            {
                Department = analyticsDepartment,
                StaffingCode = 231,
                ProfessionName = "Голова відділу аналітики"
            };

            var analystStaffing = new Staffing
            {
                Department = analyticsDepartment,
                StaffingCode = 232,
                ProfessionName = "Аналітик"
            };

            var newStaffings = new List<Staffing>
            {
                ceoStaffing,
                ceoAssistantStaffing,
                headAccountantStaffing,
                accountantStaffing,
                headOfITStaffing,
                headProjectManagerStaffing,
                projectManagerStaffing,
                headOfDevelopmentStaffing,
                teamLeadStaffing,
                netDevStaffing,
                javaDevStaffing,
                frontendDevStaffing,
                devopsStaffing,
                headOfAnalyticsStaffing,
                analystStaffing,
            };

            await _staffingsRepository.AddRangeAsync(newStaffings);
            #endregion

        }
    }
}
