using Blog.BlazorServer.ViewModels.Auth;
using static Blog.BlazorServer.ViewModels.Responses.CustomResponses;

namespace Blog.BlazorServer.Clients.Interfaces
{
    public interface IAuthClient
    {
        Task<RegistrationResponse> RegisterAsync(RegisterViewModel registerDTO);

        Task<LoginResponse> LoginAsync(LoginViewModel loginDTO);
    }
}
