using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Utilities
{
   public class TokenValidator
    {           
        public static bool ValidateToken(string headerToken)
        {
            try
            {
                TokenProviderOptions _tokenOption;
                var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var Configuration = appsettingbuilder.Build();
                _tokenOption = new TokenProviderOptions
                {
                    Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                    Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                    Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                    SecretKey = Configuration.GetSection("TokenAuthentication:SecretKey").Value
                };

                if (_tokenOption == null)
                {
                    throw new KeyNotFoundException();
                }

                bool flag = false;
                if (!string.IsNullOrEmpty(headerToken))
                {
                    var accessToken = headerToken.Replace("Bearer ", "");
                    if (TokenValidation(accessToken, _tokenOption))
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
           
        }

        private static bool TokenValidation(string token,TokenProviderOptions _tokenOption)
        {
            bool flag = false;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenOption.SecretKey));
            validationParameters.ValidAudience = _tokenOption.Audience;
            validationParameters.ValidIssuer = _tokenOption.Issuer;

            bool canRead = new JwtSecurityTokenHandler().CanReadToken(token);
            if (canRead)
            {
                ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);
                flag = true;
            }
            return flag;
        }
    }
}
