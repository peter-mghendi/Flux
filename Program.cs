using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Fluxor;
using System.Reflection;
using Flux.Services;
using Flux.Middleware;
using Blazored.LocalStorage;

namespace Flux
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") });

            // Add LocalStorage
            builder.Services.AddBlazoredLocalStorage();

            // Add Fluxor
            builder.Services.AddFluxor(options => 
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
                options.AddMiddleware<PersistenceMiddleware>();
            });
            
            builder.Services.AddScoped<StateFacade>();

            await builder.Build().RunAsync();
        }
    }
}
