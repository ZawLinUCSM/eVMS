using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilities;

namespace CMS_API.Controllers
{
    [Route("cmsapi/token")]
    [ApiController]
    [Produces("application/json")]
    public class TokenController : ControllerBase
    {
        private readonly JsonSerializerSettings _serializerSettings;
        public TokenController()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        ///  Get the token to get access to the resource.
        /// </summary>
        /// <returns>The access token</returns>
        // Get cmsapi/token
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
