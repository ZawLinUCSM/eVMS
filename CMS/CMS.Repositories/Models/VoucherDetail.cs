using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CMS.Repositories.Models
{
    public partial class VoucherDetail
    {
        [Key]
        [Column("GUID")]
        [StringLength(36)]
        public string Guid { get; set; }
        [Column("VoucherGUID")]
        [StringLength(36)]
        public string VoucherGuid { get; set; }
        [StringLength(20)]
        public string PromoCode { get; set; }
        [Column("QRCode")]
        public string Qrcode { get; set; }        
        public bool PromoCodeStatus { get; set; }
        [ForeignKey(nameof(VoucherGuid))]
        [InverseProperty(nameof(Voucher.VoucherDetail))]
        [JsonIgnore]
        public virtual Voucher VoucherGu { get; set; }
    }
}
