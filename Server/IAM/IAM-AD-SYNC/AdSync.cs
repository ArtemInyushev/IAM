using System.Net;
using IAM.Application.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IAM_AD_SYNC
{
    public class AdSync
    {
        private readonly ILogger<AdSync> _logger;
        private readonly IAdSyncService _adSyncService;

        public AdSync(IAdSyncService adSyncService, ILoggerFactory loggerFactory)
        {
            _adSyncService = adSyncService;
            _logger = loggerFactory.CreateLogger<AdSync>();
        }

        [Function("AdSync")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
