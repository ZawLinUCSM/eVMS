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

        /// <summary>
        ///  Get the token to get access to the resource.
        /// </summary>
        /// <returns>The access token</returns>
        // Get estoreapi/token
        [HttpGet]
        [Route("")]        
        public IActionResult Get()
        {
            TokenProviderMiddleware tokenProvider = new TokenProviderMiddleware();
            var response = tokenProvider.GenerateToken();
            return Ok(ResponseHelper.SuccessResponse(response));
        }
    }
}
