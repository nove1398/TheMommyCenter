using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MommyDayCare.Client.Providers;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Authorization;

namespace MommyDayCare.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddOptions();
            builder.Services.AddScoped<TokenAuthProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthProvider>();
            builder.Services.AddScoped( provider => { 
                
                return new HttpProvider("https://localhost:5001", provider.GetRequiredService<TokenAuthProvider>()); 
            } );

            await builder.Build().RunAsync();
        }
    }
}
