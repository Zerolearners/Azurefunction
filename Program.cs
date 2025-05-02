using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ai_finder_be_schedulers_donetcore;
using Microsoft.Extensions.Configuration;
using ai_finder_be_schedulers_donetcore.Configuration;
using ai_finder_be_schedulers_donetcore.Common;
using Npgsql;
using Microsoft.ApplicationInsights.WorkerService;
using ai_finder_be_schedulers_donetcore.Features.PushNotification;


DotNetEnv.Env.Load();
var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

var finderSetting = config.Get<FinderSetting>();
var mailSetting = config.Get<MailSetting>();


if (finderSetting == null || string.IsNullOrEmpty(finderSetting.FINDER_DB_CONNECTION_STRING) || mailSetting == null)
{
    throw new InvalidOperationException("FINDER_DB_CONNECTION_STRING is not set in the configuration.");
}

// Configure Npgsql to use Newtonsoft JSON.NET for JSON serialization
NpgsqlConnection.GlobalTypeMapper.UseJsonNet();


var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<FinderSchedulerDbContext>(options => options.UseNpgsql(finderSetting.FINDER_DB_CONNECTION_STRING));

        AddDependency addDependency = new();
        addDependency.AddDependencies(services, finderSetting, mailSetting);
    })
    .Build();

host.Run();