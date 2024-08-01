using Blog.Business.DTOs.Auth;
using static Blog.Business.DTOs.Responses.CustomResponses;

namespace Blog.Business.Interfaces
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO registerDTO);

        Task<LoginResponse> LoginAsync(LoginDTO loginDTO);

        // LoginResponse RefreshToken(UserSession userSession);
    }
}
