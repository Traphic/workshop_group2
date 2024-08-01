using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blog.BlazorServer.States
{
    public static class DecryptJWTTokenService
    {
        public static CustomUserClaims DecryptToken(string jwtToken)
        {
            try
            {
                if (jwtToken is null)
                {
                    return new CustomUserClaims();
                }

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);

                var name = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                var email = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                return new CustomUserClaims(name!.Value, email!.Value);
            }
            catch
            {
                return null;
            }
        }
    }
}
