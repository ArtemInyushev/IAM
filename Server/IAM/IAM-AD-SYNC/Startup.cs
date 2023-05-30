using IAM.Application.Interfaces;
using IAM.Application.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(IAM_AD_SYNC.Startup))]
namespace IAM_AD_SYNC
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            var iamConnectionString = configuration.GetConnectionString("IAMConnectionString");

            builder.Services.AddScoped<IAdSyncService, AdSyncService>();
        }
    }
}
