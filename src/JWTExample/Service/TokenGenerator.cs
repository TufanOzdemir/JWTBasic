using JWTExample.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace JWTExample.Service
{
    public class TokenGenerator
    {
        private readonly IConfigResolver _configResolver;

        public TokenGenerator(IConfigResolver configResolver)
        {
            _configResolver = configResolver;
        }

        public string GetToken()
        {
            var authConfig = _configResolver.Resolve<AuthenticationConfig>();
            var symmetricKey = Convert.FromBase64String(authConfig.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var roles = new List<string>() { "A", "B", "C" };
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.GivenName, "Fatih"));
            claims.Add(new Claim(ClaimTypes.Surname, "Ceritli"));
            claims.Add(new Claim(ClaimTypes.Email, "fatih@lineajans.com"));
            claims.AddRange(roles.Select(c => new Claim(ClaimTypes.Role, c)));

            var now = DateTime.Now;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "JWTExample",
                IssuedAt = now,
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(authConfig.ExpireMinutes),
                NotBefore = now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
