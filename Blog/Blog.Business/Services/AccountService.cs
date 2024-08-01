using AutoMapper;
using Blog.Business.DTOs.Auth;
using Blog.Business.Interfaces;
using Blog.Data.Data;
using Blog.Data.Enums;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Blog.Business.DTOs.Responses.CustomResponses;

namespace Blog.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AccountService(BlogDbContext dbContext, IConfiguration config, IMapper mapper)
        {
            _dbContext = dbContext;
            _config = config;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginAsync(LoginDTO loginDTO)
        {
            var findUser = await GetUserAsync(loginDTO?.Email);
            if (findUser is null)
            {
                return new LoginResponse(false, "User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, findUser.Password))
            {
                return new LoginResponse(false, "Email/Password not valid");

            }

            string jwtToken = GenerateToken(findUser);

            return new LoginResponse(true, "Login completed", jwtToken!);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO registerDTO)
        {
            var findUser = await GetUserAsync(registerDTO?.Email);
            if (findUser is not null)
            {
                return new RegistrationResponse(false, "User already exist.");
            }

            _dbContext.ApplicationUsers.Add(
                new ApplicationUser()
                {
                    Username = registerDTO.Username,
                    Email = registerDTO.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                    Role = Role.User
                });
            await _dbContext.SaveChangesAsync();

            return new RegistrationResponse(true, "User successfuly created.");
        }

        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> GetUserAsync(string email) => await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
    }
}
