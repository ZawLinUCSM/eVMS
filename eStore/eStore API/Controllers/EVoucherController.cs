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
    public class EVoucherController : BaseController
    {
        readonly IEVoucherService _eVoucherServices;   
        public EVoucherController(IEVoucherService eVoucherService)
        {
            _eVoucherServices = eVoucherService;            
        }

        /// <summary>
        ///  Return evouchers list
        /// </summary>
        /// <returns>Return evouchers list</returns>
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
        ///  Return Purchase history list
        /// </summary>
        /// <returns>Return Purchase history list</returns>
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
        ///  Return details of eVoucher by promocode
        /// </summary>
        /// <param name="promocode"></param>
        /// <returns>Return details of eVoucher</returns>
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
        ///  Verify the status of eVoucher
        /// </summary>
        /// <param name="promocode"></param>
        /// <returns>Return the status of eVoucher</returns>
        [Authorize]
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
