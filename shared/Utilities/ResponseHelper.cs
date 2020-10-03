using Microsoft.AspNetCore.Http;

namespace Utilities
{
    public class ResponseHelper
    {     

        public static dynamic SuccessResponse(dynamic data,int statusCode=StatusCodes.Status200OK)
        {           
            var response = new
            {
                status = "true",
                code= statusCode,
                message = "success",
                data = data
            };
            return response;
        }

        public static dynamic FailRespose(dynamic data, int statusCode = StatusCodes.Status501NotImplemented)
        {
           
            var response = new
            {
                status = "false",
                code = statusCode,
                message = "fail",
                data = data
            };
            return response;
        }
    }
}
