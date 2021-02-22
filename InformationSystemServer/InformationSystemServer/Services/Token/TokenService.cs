using InformationSystemServer.Data.Models;
using InformationSystemServer.Services.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InformationSystemServer.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration tokenConfiguration;

        public TokenService(IOptions<TokenConfiguration> tokenConfigurationOptions)
        {
            this.tokenConfiguration = tokenConfigurationOptions.Value;
        }

        public string CreateToken(User user)
        {
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username),
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.tokenConfiguration.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = this.tokenConfiguration.Issuer,
                Audience = this.tokenConfiguration.Audience,
                Expires = DateTime.UtcNow.AddDays(this.tokenConfiguration.Expires),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
