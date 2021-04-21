using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AquitoApi.Entities;
using AquitoApi.Helpers.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AquitoApi.Services
{
    public class TokenService : ITokenService
    {

        private readonly AppSettings _appSettings;
        private readonly UserManager<Useraquito> _userManager;

        public TokenService(IOptions<AppSettings> appSettings, UserManager<Useraquito> userManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        public async Task<(string, IEnumerable<string>)> GenerateJwtToken(Useraquito user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIndentity = new ClaimsIdentity(
                new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // for refresh token
                }
            );

            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            foreach (string userRole in userRoles)
            {
                claimsIndentity.AddClaim(new Claim(ClaimTypes.Role, userRole));
            }

            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIndentity,
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);

            string jwtToken = jwtTokenHandler.WriteToken(token);


            return (jwtToken, userRoles);
        }
    }
}