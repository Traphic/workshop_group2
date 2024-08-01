using Blog.BlazorServer.ViewModels.Auth;
using Blog.BlazorServer.Clients.Interfaces;
using static Blog.BlazorServer.ViewModels.Responses.CustomResponses;

namespace Blog.BlazorServer.Clients
{
    public class AuthClient : IAuthClient
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "api/account";

        public AuthClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterViewModel registerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/register", registerDTO);
            var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();

            return result;
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel loginDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/login", loginDTO);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            return result;
        }
    }
}
