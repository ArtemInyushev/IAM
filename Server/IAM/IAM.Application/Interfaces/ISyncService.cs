namespace IAM.Application.Interfaces
{
    public interface ISyncService
    {
        Task SyncEmployees();
        Task SyncGroups();
    }
}
