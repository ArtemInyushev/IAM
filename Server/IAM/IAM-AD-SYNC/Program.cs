using IAM.Application.Interfaces;
using IAM.Application.Options;
using IAM.Application.Services;
using IAM.Core.Interfaces;
using IAM.Infrastructure.Data;
using IAM.Infrastructure.Repositories;
using IAM_AD_SYNC.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((hostContext, configBuilder) =>
    {
        configBuilder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
        configBuilder.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        services.AddDbContext<IamDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IAMConnectionString"));
        });
        services.AddScoped(typeof(IRepository<>), typeof(IamRepository<>));

        services.Configure<AdOptions>(configuration.GetSection("AzureAd"));

        services.AddScoped<IAdSyncService, AdSyncService>();

        services.AddAutoMapper(typeof(MappingProfile));
    })
    .Build();

host.Run();
