using IAM.Application.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace IAM_AD_SYNC
{
    public class AdSyncTimer
    {
        private readonly IAdSyncService _adSyncService;
        private readonly ILogger<AdSyncTimer> _logger;

        public AdSyncTimer(IAdSyncService adSyncService, ILoggerFactory loggerFactory)
        {
            _adSyncService = adSyncService;
            _logger = loggerFactory.CreateLogger<AdSyncTimer>();
        }

        [Function("AdSyncTimer")]
        public async Task Run([TimerTrigger("0 */30 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _adSyncService.SyncEmployeesAndGroups();

            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
