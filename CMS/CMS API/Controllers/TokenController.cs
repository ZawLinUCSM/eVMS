﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace CMS_API.Controllers
{
    [Route("cmsapi/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public dynamic Get()
        {
            TokenProviderMiddleware tokenProvider = new TokenProviderMiddleware();

            return tokenProvider.GenerateToken();
        }
    }
}
