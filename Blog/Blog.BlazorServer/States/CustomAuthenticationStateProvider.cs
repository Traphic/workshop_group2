using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Blog.BlazorServer.States
{
    public class CustomAuthenticationStateProvider: AuthenticationStateProvider
    {
        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _localStorageService.GetItemAsync<string>("token");

                if (string.IsNullOrEmpty(token))
                {
                    return await Task.FromResult(new AuthenticationState(anonymous));
                }

                var getUserClaims = DecryptJWTTokenService.DecryptToken(token);
                if (getUserClaims is null)
                {
                    return await Task.FromResult(new AuthenticationState(anonymous));
                }

                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task UpdateAuthenticationState(string? token)
        {
            ClaimsPrincipal claimsPrincipal = new();
            if (!string.IsNullOrWhiteSpace(token))
            {
                await _localStorageService.SetItemAsync("token", token);
                var getUserClaims = DecryptJWTTokenService.DecryptToken(token);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                claimsPrincipal = anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims is null || claims.Email is null)
            {
                return new ClaimsPrincipal();
            }

            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, claims.Name!),
                         new Claim(ClaimTypes.Email, claims.Email!),
                    }, "JwtAuth"));
        }
    }
}
