namespace IAM.Application.Interfaces
{
    public interface ISyncService
    {
        Task SyncEmployeesAndGroups();
        Task SyncEmployees();
        Task SyncGroups();
    }
}
