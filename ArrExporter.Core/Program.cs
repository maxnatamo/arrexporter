using Serilog;

using ArrExporter.Influx;

namespace ArrExporter.Core
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Information()
                .CreateLogger();

            await Broker.Initialize();

            while(true)
            {
                Log.Information("Updating data...");

                await Broker.Render();

                Log.Information("Update complete.");

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}