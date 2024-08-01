using Blog.Business.DTOs.Auth;
using Blog.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Blog.Business.DTOs.Responses.CustomResponses;

namespace Blog.WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegisterDTO registerDTO)
        {
            var response = await _accountService.RegisterAsync(registerDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDTO loginDTO)
        {
            var response = await _accountService.LoginAsync(loginDTO);
            return Ok(response);
        }
    }
}
