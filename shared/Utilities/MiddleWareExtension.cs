using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Utilities
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenProviderMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenProviderMiddleware>();
        }
        
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {          
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwt =>
            {

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("TokenAuthentication:SecretKey").Value));
                jwt.TokenValidationParameters = new TokenValidationParameters
                {

                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = config.GetSection("TokenAuthentication:Issuer").Value,
                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = config.GetSection("TokenAuthentication:Audience").Value,
                    // Validate the token expiry
                    ValidateLifetime = true,
                    // If you want to allow a certain amount of clock drift, set that here:
                    ClockSkew = TimeSpan.Zero
                };

                string key = config.GetSection("TokenAuthentication:SecretKey").Value;
                double expiretimespan = Convert.ToDouble(config.GetSection("TokenAuthentication:TokenExpire").Value);

                jwt.SecurityTokenValidators.Clear();
                jwt.SecurityTokenValidators.Add(new OAuthTokenHandler(expiretimespan, key));
            });
        }

        public static void ConfigureTokenOptions(this IServiceCollection services, IConfiguration config)
        {
            var tokenProviderOptions = new TokenProviderOptions();
            config.Bind("TokenAuthentication", tokenProviderOptions);
            services.AddSingleton(tokenProviderOptions);

        }
    }

  
}   
