using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace eStoreAPI.Controllers
{
    [Route("estoreapi/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }     

        /// <summary>
        ///  Return Payment Method list
        /// </summary>
        /// <returns>Return Payment Method list</returns>
        [HttpGet]
        [Route("types")]
        public async Task<dynamic> GetPaymentTypes()
        {
            try
            {
                var vouchers = await _paymentService.GetPaymentTypes();               
                return Ok(ResponseHelper.SuccessResponse(vouchers));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }               

        /// <summary>
        ///  Make a payment
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public string DoPayment(string promocode)
        {
            // Confirm first
            // Generate Promo Codes
            // Then save to DB
            return "";
        }
    }
}
