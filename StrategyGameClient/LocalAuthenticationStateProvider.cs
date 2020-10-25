using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StrategyGameClient.Models;

namespace StrategyGame.Client
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;

        public LocalAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if( await this.localStorageService.ContainKeyAsync("User"))
            {
                var userInfo = await this.localStorageService.GetItemAsync<LocalUserInfo>("User");

                var claims = new[]
                {
                    new Claim("Email", userInfo.Email),
                    new Claim("UserName", userInfo.UserName),
                    new Claim("NinckName", userInfo.NickName),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
                    new Claim("AccesToken", userInfo.AccesToken),
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);

                var state =  new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogOutAsync()
        {
            await this.localStorageService.RemoveItemAsync("User");
            this.NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
