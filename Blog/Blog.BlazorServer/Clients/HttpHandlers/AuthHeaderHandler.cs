using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Blog.BlazorServer.Clients.HttpHandlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;

        public AuthHeaderHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await _localStorageService.GetItemAsync<string>("token");

            if (!string.IsNullOrEmpty(token) && request is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
