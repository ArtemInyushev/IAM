using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Function1
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            // Configure your services and settings here
            ConfigureServices(builder.Services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Add your services to the service collection
            // For example:
            // services.AddTransient<ISomeService, SomeService>();
        }
    }
}