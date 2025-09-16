using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using UsersAPI.Domain.Interfaces.Security;
using UsersAPI.Domain.ValueObjects;
using UsersAPI.Infra.Security.Settings;

namespace UsersAPI.Infra.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }

        public string CreateToken(UserAuthVO userAuth)
        {
            //definir as CLAIMS que serão gravadas no token (identificações para o usuário)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userAuth)),
                new Claim(ClaimTypes.Role, userAuth.Role),
            };

            //gerando a assinatura antifalsificação do token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings?.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //preenchendo as informações do token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenSettings?.Issuer,
                audience: _tokenSettings?.Audience,
                claims: claims, //informações de identificação do usuário
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_tokenSettings?.ExperationInMinutes)),
                signingCredentials: credentials //assinatura do token
                );

            //retornando o token
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
