using System;
using System.Threading.Tasks;
using IAM.Application.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace IAM_AD_SYNC
{
    public class AdSync
    {
        private readonly IAdSyncService _adSyncService;

        public AdSync(IAdSyncService adSyncService)
        {
            _adSyncService = adSyncService;
        }

        [FunctionName("AdSync")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
