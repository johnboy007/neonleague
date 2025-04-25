using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeonLeague.Data;

namespace NeonLeague;

internal class Program
{
    private static IConfiguration _configuration;

    private static async Task Main(string[] args)
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();
        var serviceCollection = ConfigureServices();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var sp = serviceProvider.GetService<NeonLeagueService>();
        if (sp != null) await sp.Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<NeonLeagueService>();
        services.AddSingleton<ITeamsBuilder, TeamsBuilder>();
        services.AddSingleton<IDbContext, DbContext>();
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
        });
        return services;
    }
}