using System.Net;
using IAM.Application.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IAM_AD_SYNC
{
    public class AdSync
    {
        private readonly IAdSyncService _adSyncService;
        private readonly ILogger<AdSyncTimer> _logger;

        public AdSync(IAdSyncService adSyncService, ILoggerFactory loggerFactory)
        {
            _adSyncService = adSyncService;
            _logger = loggerFactory.CreateLogger<AdSyncTimer>();
        }

        [Function("AdSync")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            await _adSyncService.SyncEmployeesAndGroups();

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
