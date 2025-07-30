using LabForWeb.EC.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LabForWeb.EC.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7257") });
        builder.Services.AddScoped<IECService, ECService>();
        builder.Services.AddOidcAuthentication(options =>
        {
            // Configure your authentication provider options here.
            // For more information, see https://aka.ms/blazor-standalone-auth
            builder.Configuration.Bind("Local", options.ProviderOptions);
        });

        await builder.Build().RunAsync();
    }
}
