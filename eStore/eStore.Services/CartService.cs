using eStore.Repositories.Interfaces;
using Entities.Models;
using eStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStore.Services
{
    public class CartService : ICartService
    {
        readonly IPaymentRepository _evoucherRepository;
        public CartService(IPaymentRepository eVoucherRepository)
        {
            _evoucherRepository = eVoucherRepository;
        }       

        public async Task<IEnumerable<Voucher>> GetShoppingCartItem(string userGuid)
        {
            //return await _evoucherRepository.GetVouchers();
            throw new System.NotImplementedException();
        }
    }
}
