using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using com.expenses.domain.DomainModel.Login;
using com.expenses.tools;

namespace com.expenses.service.Token
{
    public static class TokenService
    {
        public static string GenerateToken (LoginModel login)
        {           
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.TokenSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: TokenSettings.Issuer, audience: TokenSettings.Audience,
                                    expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(TokenSettings.TokenSecret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[] { new Claim("id", login.Id.ToString())}),
            //    Expires = DateTime.UtcNow.AddDays(30),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
        }

        public static bool ValidateJwtToken(string token)
        {
            bool isValid = false;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(TokenSettings.TokenSecret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = TokenSettings.Issuer,
                    ValidAudience = TokenSettings.Audience,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // return account id from JWT token if validation successful
                isValid = jwtToken != null;
            }
            catch (Exception)
            {
            }

            return isValid;
            
            
        }
    }
}
