using Azure.Identity;
using IAM.Application.Interfaces;
using IAM.Application.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace IAM.Application.Services
{
    public class AdSyncService : IAdSyncService
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<AdSyncService> _logger;

        public AdSyncService(IOptions<AdOptions> adOptions, ILogger<AdSyncService> logger)
        {
            _logger = logger;

            var options = adOptions.Value;
            var credentials = new ClientSecretCredential(options.TenantId, options.ClientId, options.ClientSecret);
            _graphServiceClient = new GraphServiceClient(credentials);
        }

        public async Task SyncEmployeesAndGroups()
        {
            try
            {
                var users = await _graphServiceClient.Users.GetAsync();
                foreach (var user in users.Value)
                {
                    var tmp = user;
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        public async Task SyncEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task SyncGroups()
        {
            throw new NotImplementedException();
        }
    }
}
