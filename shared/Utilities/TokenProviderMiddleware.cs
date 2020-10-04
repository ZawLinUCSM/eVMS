
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Utilities
{
    public class TokenProviderMiddleware : IMiddleware
    {
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
        }
        public TokenProviderMiddleware()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var Configuration = appsettingbuilder.Build();
            double expiretimespan = Convert.ToDouble(Configuration.GetSection("TokenAuthentication:TokenExpire").Value);
            TimeSpan expiration = TimeSpan.FromMinutes(expiretimespan);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            _options = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity,
                Expiration = expiration
            };
        }
        public async Task ResponseMessage(dynamic data, HttpContext context, int code = 400)
        {
            var response = new
            {
                status = data.status,
                message = data.message
            };
            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
            //return;
        }

        private async Task GenerateToken(HttpContext context)
        {

            var now = DateTime.UtcNow;
            var _tokenData = new TokenData();
            _tokenData.Sub = "Zawlinhtay";
            _tokenData.Jti = await _options.NonceGenerator();
            _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
            _tokenData.TicketExpireDate = now.Add(_options.Expiration);
            var claims = GetClaims(_tokenData);

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                data =
                new
                {
                    access_token = encodedJwt,
                    expires_in = (int)_options.Expiration.TotalSeconds
                }
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }
        public async Task<dynamic> GenerateToken()
        {

            var now = DateTime.UtcNow;
            var _tokenData = new TokenData();
            _tokenData.Sub = "Zawlinhtay";
            _tokenData.Jti = await _options.NonceGenerator();
            _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
            _tokenData.TicketExpireDate = now.Add(_options.Expiration);
            var claims = GetClaims(_tokenData);

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };
            return response;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            TokenData _tokenData = null;
            var pathstr = "";
            var access_token = "";
            var hdtoken = context.Request.Headers["Authorization"];
            pathstr = context.Request.Path.ToString();
            if (hdtoken.Count > 0)
            {
                try
                {
                    access_token = hdtoken[0];
                    access_token = access_token.Replace("Bearer ", "");
                    var handler = new JwtSecurityTokenHandler();
                    var tokenS = handler.ReadToken(access_token) as JwtSecurityToken;
                    _tokenData = GetTokenData(tokenS);

                    //Regenerate newtoken for not timeout at running
                    string newToken = "";

                    // check token expired   
                    double expireTime = Convert.ToDouble(_options.Expiration.TotalMinutes);
                    DateTime issueDate = _tokenData.TicketExpireDate.AddMinutes(-expireTime);
                    DateTime NowDate = DateTime.UtcNow;
                    if (issueDate > NowDate || _tokenData.TicketExpireDate < NowDate)
                    {
                        await ResponseMessage(new { status = "fail", message = "The Token has expired" }, context, 400);
                    }
                    // end of token expired check

                    var now = DateTime.UtcNow;
                    _tokenData.Jti = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
                    _tokenData.Jti = await _options.NonceGenerator();

                    var claims = GetClaims(_tokenData);
                    // Create the JWT and write it to a string
                    var jwt = new JwtSecurityToken(
                        issuer: _options.Issuer,
                        audience: _options.Audience,
                        claims: claims,
                        notBefore: now,
                        expires: now.Add(_options.Expiration),
                        signingCredentials: _options.SigningCredentials);
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    newToken = encodedJwt;


                    if (newToken != "")
                    {
                        context.Response.Headers.Add("Access-Control-Expose-Headers", "newToken");
                        context.Response.Headers.Add("newToken", newToken);
                        await next(context);
                    }

                }
                catch (Exception ex)
                {
                    await ResponseMessage(new { status = "fail", message = ex.Message.ToString() }, context, 400);
                }
            }
            else
            {
                if (pathstr.Contains("/token"))
                    await next(context);
                else
                    await ResponseMessage(new { status = "fail", message = "You have no authorization, generate token and Add authorization header with Bearer Token. To generate token use this url : https://localhost:44365/cmsapi/token" }, context, 401);
                //await GenerateToken(context);
                //await next(context);
            }

        }

        public Claim[] GetClaims(TokenData obj)
        {
            var claims = new Claim[]
            {
                new Claim("TicketExpireDate", obj.TicketExpireDate.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, obj.Sub),
                new Claim(JwtRegisteredClaimNames.Jti, obj.Jti),
                new Claim(JwtRegisteredClaimNames.Iat, obj.Iat, ClaimValueTypes.Integer64)
            };
            return claims;
        }

        public TokenData GetTokenData(JwtSecurityToken tokenS)
        {
            var obj = new TokenData();
            try
            {
                obj.Sub = tokenS.Claims.First(claim => claim.Type == "sub").Value;
                string TicketExpire = tokenS.Claims.First(claim => claim.Type == "TicketExpireDate").Value;
                DateTime TicketExpireDate = DateTime.Parse(TicketExpire);
                obj.TicketExpireDate = TicketExpireDate;
            }
            catch
            {

            }
            return obj;
        }
    }
}
