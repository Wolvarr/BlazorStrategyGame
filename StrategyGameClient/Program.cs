using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StrategyGameClient.Models;
using System.Numerics;
using StrategyGameClient.Enums;
using StrategyGame.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using StrategyGame.Client;

namespace StrategyGameClient
{
    public class Program
    {

        private const string GameServerURL = "https://localhost:44372";
        private const string GameEngineURL = "http://localhost:51554";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(GameEngineURL) });
            builder.Services.AddScoped(s =>
            {
                return new AuthenticationService(GameServerURL);
            });
            builder.Services.AddScoped(s =>
            {
                return new LobbyService(GameServerURL);
            });
            builder.Services.AddScoped(s =>
            {
                return new GameService(GameEngineURL);
            });

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            await builder.Build().RunAsync();
        }
    }
}
