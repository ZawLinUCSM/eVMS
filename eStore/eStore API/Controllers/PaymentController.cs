using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace eStoreAPI.Controllers
{
    [Route("estoreapi/payment")]
    [ApiController]
    [Authorize]
    public class PaymentController : BaseController
    {
        readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }     

        /// <summary>
        ///  Payment Methods
        /// </summary>
        /// <returns>The list of payment methods</returns>
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
        public async Task<dynamic> DoPayment(Voucher voucher)
        {
            // Confirm first
            // Generate Promo Codes
            // Then save to DB
            try
            {
                var isSuccess = await _paymentService.DoPayment(voucher);
                var message = isSuccess ? "Payment is successfully done" : "Transaction Time out";
                return Ok(ResponseHelper.SuccessResponse(message));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }           
        }
    }
}
