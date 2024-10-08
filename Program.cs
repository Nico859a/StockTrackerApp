using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockQuotesApp;
using StockQuotesApp.Services;
using Syncfusion.Licensing;

namespace StockTrackerApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Register Syncfusion license key
            SyncfusionLicenseProvider.RegisterLicense("MzUwODA5NEAzMjM3MmUzMDJlMzBBMFlZSm5ya0ZocnlxdFdoa0QyaXdXTlZuczNUUFF4eWU0T3pCQWVsLy80PQ==");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AlphaVantageService>();
            builder.Services.AddScoped<AuthService>();

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            await builder.Build().RunAsync();
        }
    }
}