using dotnet_code_challenge.DataProvider;
using dotnet_code_challenge.Helper;
using dotnet_code_challenge.Manager;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    public static class Bootstraper
    {
        public static ServiceProvider serviceProvider { get; private set; }

        public static void SetupAutofac()
        {
            serviceProvider = new ServiceCollection()
                        .AddSingleton<IDataProvider, CaulfieldRaceDataProvider>()
                        .AddSingleton<IDataProvider, WolferhamptonRaceDataProvider>()
                        .AddSingleton<IRaceDataManager, RaceDataManager>()
                        .AddSingleton<ILogger, ConsoleLogger>()
                        .AddSingleton<ISourceProvider, SourceProvider>()
                        .BuildServiceProvider();
        }
    }
}
