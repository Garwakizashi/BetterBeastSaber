﻿namespace BetterBeastSaber.Scraper
{
    class Program
    {
        static Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
              .ConfigureServices((_, services) =>
              {
                  services.AddOptions();
                  services.AddSingleton(BrowsingContext.New(Configuration.Default.WithDefaultLoader()));
                  services.AddSingleton(typeof(Scraper));
                  services.AddHostedService<ScraperWorker>();
              })
              .ConfigureLogging(bldr =>
              {
                  bldr.ClearProviders();
                  bldr.AddConsole()
                    .SetMinimumLevel(LogLevel.Error);
              })
              .Build();

            return host.RunAsync();
        }
    }
}
