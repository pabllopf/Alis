using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Alis.App.Engine.Web;
using Microsoft.Extensions.DependencyInjection;

namespace Alis.App.Engine.Web
{
    /// <summary>
    /// The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            await builder.Build().RunAsync();
        }
    }
}

