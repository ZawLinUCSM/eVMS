using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Voucher>> GetShoppingCartItem(string userGuid);       
    }
}
