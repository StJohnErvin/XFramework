namespace Wallets.Api;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseDefaultServiceProvider(options => options.ValidateScopes = false)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSentry(o =>
                {
                    o.Dsn = "https://38a9ae89bc8d4c169281adbda1b733cf@o1146205.ingest.sentry.io/6504184";
                    // When configuring for the first time, to see what the SDK is doing:
                    o.Debug = true;
                    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                    // We recommend adjusting this value in production.
                    o.TracesSampleRate = 1.0;
                });
                webBuilder.UseStartup<Startup>();
            });
}