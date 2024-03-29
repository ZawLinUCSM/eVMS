﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Utilities
{
    public class OAuthTokenHandler : ISecurityTokenValidator
    {
        private int m_MaximumTokenByteSize;
        private double expiretimespan;
        private string key;
        public OAuthTokenHandler(double expiretimespan, string key)
        {
            this.expiretimespan = expiretimespan;
            this.key = key;
        }

        bool ISecurityTokenValidator.CanValidateToken
        {
            get
            {
                return true;
            }
        }

        int ISecurityTokenValidator.MaximumTokenSizeInBytes
        {
            get
            {
                return this.m_MaximumTokenByteSize;
            }

            set
            {
                this.m_MaximumTokenByteSize = value;
            }
        }

        bool ISecurityTokenValidator.CanReadToken(string securityToken)
        {
            System.Console.WriteLine(securityToken);
            return true;
        }

        ClaimsPrincipal ISecurityTokenValidator.ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = null;
            validatedToken = null;

            System.Collections.Generic.List<System.Security.Claims.Claim> ls =
                new System.Collections.Generic.List<System.Security.Claims.Claim>();

            ls.Add(
                new System.Security.Claims.Claim(
                    System.Security.Claims.ClaimTypes.Name, "Zawlinhtay"
                , System.Security.Claims.ClaimValueTypes.String
                )
            );

            System.Security.Claims.ClaimsIdentity id = new System.Security.Claims.ClaimsIdentity("authenticationType");
            id.AddClaims(ls);

            principal = new System.Security.Claims.ClaimsPrincipal(id);

            return principal;
            throw new NotImplementedException();
        }
    }
}
