using System;
using System.Threading.Tasks;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace eStoreAPI.Controllers
{
    [Route("estoreapi/cart")]
    [ApiController]
    [Authorize]
    public class CartController : BaseController
    {
        readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }              

        /// <summary>
        ///   the items in the shopping cart
        /// </summary>       
        /// <returns>Return the item in the shopping cart</returns>
        // GET estoreapi/cart/checkout
        [HttpGet]
        [Route("checkout")]
        public async Task<dynamic> GetShoppingCartItem(string userGuid)
        {
            try
            {
                var vouchers = await _cartService.GetShoppingCartItem(userGuid);          
                return Ok(ResponseHelper.SuccessResponse(vouchers));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }

        }       
    }
}
