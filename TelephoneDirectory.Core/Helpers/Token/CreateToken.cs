using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace TelephoneDirectory.Core.Helpers.Token
{
    public class CreateToken
    {
        private readonly IConfiguration _configuration;

        public CreateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateTokenHandler(TokenRequestModel tokenRequest)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(tokenRequest.Id)),
                new Claim(ClaimTypes.Name,tokenRequest.UserName),
                new Claim(ClaimTypes.GivenName,tokenRequest.FirstName),
                new Claim(ClaimTypes.Surname, tokenRequest.LastName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value
                ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
             issuer: _configuration["AppSettings:Issuer"],
             audience: _configuration["AppSettings:Audience"],
             claims: claims,
             expires: DateTime.Now.AddMinutes(300),
             signingCredentials: cred);
  
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
