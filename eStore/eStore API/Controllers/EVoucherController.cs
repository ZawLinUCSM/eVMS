using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace eStoreAPI.Controllers
{
    [Route("estoreapi/evoucher")]
    [ApiController]   
    [Authorize]
    public class EVoucherController : BaseController
    {
        readonly IEVoucherService _eVoucherServices;   
        public EVoucherController(IEVoucherService eVoucherService)
        {
            _eVoucherServices = eVoucherService;            
        }

        /// <summary>
        ///  List of  evouchers
        /// </summary>
        /// <returns>The list of evouchers </returns>
        [HttpGet]
        [Route("")]
        public async Task<dynamic> GeteVouchers()
        {
            try
            {
                var vouchers = await _eVoucherServices.GetVouchers();              

                return Ok(ResponseHelper.SuccessResponse(vouchers));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }      

        /// <summary>
        ///  The purchase history list for a customer
        /// </summary>
        /// <returns>The list of purchase history for a customer</returns>
        [HttpGet]
        [Route("customers/{customerguid}/purchasehistories")]
        public async Task<dynamic> GetPurchaseHistories(string customerguid)
        {
            try
            {
                var vouchers = await _eVoucherServices.GetPurchaseHistories(customerguid);               

                return Ok(ResponseHelper.SuccessResponse(vouchers));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }

        /// <summary>
        ///  Return details of eVoucher by guid
        /// </summary>
        /// <param name="voucherguid"></param>
        /// <returns>The details of a eVoucher</returns>
        [HttpGet]
        [Route("{voucherguid}/details")]
        public async Task<dynamic> GetDetails(string voucherguid)
        {
            try
            {
                var vouchers = await _eVoucherServices.GetVoucherDetail(voucherguid);

                return Ok(ResponseHelper.SuccessResponse(vouchers));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }

        /// <summary>
        ///  Verify the status of eVoucher with promocode
        /// </summary>
        /// <param name="promocode"></param>
        /// <returns> The status of a eVoucher</returns>       
        [HttpGet]
        [Route("{promocode}/verify")]
        public async Task<dynamic> VerifyeVoucher(string promocode)
        {
            try
            {
                var isValid = await _eVoucherServices.CheckPromoCode(promocode);
                var status = isValid ? "Valid voucher" : "Invalid Voucher";

                return Ok(ResponseHelper.SuccessResponse(status));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }

     
    }
}
