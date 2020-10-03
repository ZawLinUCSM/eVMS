using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Utilities;

namespace eStoreAPI.Controllers
{   
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
                        
            var headerToken = Request.Headers["Authorization"];

            if (!TokenValidator.ValidateToken(headerToken))
                throw new UnauthorizedAccessException("You have no authorization to get this resource");
        }
    }
}
