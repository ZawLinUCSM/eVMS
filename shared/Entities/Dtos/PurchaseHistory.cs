using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class PurchaseHistory
    {
        public List<VoucherDetail> UnUsed { get; set; }
        public List<VoucherDetail> Used { get; set; }     
    }

}
