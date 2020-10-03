using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Repositories.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace CMS_API.Controllers
{
    [Route("cmsapi/evoucher")]
    [ApiController]
    [Authorize]
    public class EVoucherController : BaseController
    {
        readonly IEVoucherServices _eVoucherServices;
        public EVoucherController(IEVoucherServices eVoucherService)
        {
            _eVoucherServices = eVoucherService;
        }

        [HttpGet]
        [Route("")]
      
        public string Get()
        {
            return "Welcome from CMS API. API is running....";
        }

        [HttpGet]
        [Route("list")]       
        public async Task<dynamic> GetVoucherList()
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
        /// Create eVoucher
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<dynamic> CreateVoucher(Voucher voucher)
        {
            try
            {
                // Create voucher  
                await _eVoucherServices.Create(voucher);
                return Ok(ResponseHelper.SuccessResponse("Created successfully"));
            }
            catch (Exception ex)
            {

                return Ok(ResponseHelper.FailRespose(ex.Message));
            }

        }

        /// <summary>
        /// Update eVoucher
        /// </summary>        
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<dynamic> UpdateVoucher(Voucher voucher)
        {
            try
            {

                await _eVoucherServices.Update(voucher);
                return Ok(ResponseHelper.SuccessResponse("Updated successfully"));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }

        /// <summary>
        /// Delete eVoucher
        /// </summary>        
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<dynamic> DeactivateVoucher(Voucher voucher)
        {
            try
            {
                await _eVoucherServices.Delete(voucher);
                return Ok(ResponseHelper.SuccessResponse("Deleted successfully"));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.FailRespose(ex.Message));
            }
        }
    }
}
