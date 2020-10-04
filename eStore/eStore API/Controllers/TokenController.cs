using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCode_MS;
using Utilities;

namespace eStoreAPI.Controllers
{
    [Route("estoreapi/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public dynamic Get()
        {
           
            TokenProviderMiddleware tokenProvider = new TokenProviderMiddleware();
            return  tokenProvider.GenerateToken();
        }
    }
}
