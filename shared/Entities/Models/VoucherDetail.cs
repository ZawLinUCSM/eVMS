
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
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
        public string Qrcode { get; set; } // To store only Base64 string to the database instead image  
        public bool PromoCodeStatus { get; set; } // True is used & False is unused code
        [ForeignKey(nameof(VoucherGuid))]
        [InverseProperty(nameof(Voucher.VoucherDetail))]
        [JsonIgnore]
        public virtual Voucher VoucherGu { get; set; }
    }
}
