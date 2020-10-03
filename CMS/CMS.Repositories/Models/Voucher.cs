using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CMS.Repositories.Models
{
    public partial class Voucher
    {
        [Key]
        [Column("GUID")]
        [StringLength(36)]
        public string Guid { get; set; }
        [Column("CustomerGUID")]
        [StringLength(36)]
        public string CustomerGuid { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireDate { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        public int? Qty { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
        [StringLength(20)]
        public string BuyType { get; set; }
        [StringLength(10)]       
        public string Status { get; set; }

        [ForeignKey(nameof(CustomerGuid))]
        [InverseProperty(nameof(Customer.Vouchers))]
        [JsonIgnore]
        public virtual Customer CustomerGu { get; set; }
        [ForeignKey(nameof(PaymentType))]
        [InverseProperty("Vouchers")]
        [JsonIgnore]
        public virtual PaymentType PaymentTypeNavigation { get; set; }
        [InverseProperty("VoucherGu")]
        //[JsonIgnore]
        public virtual ICollection<VoucherDetail> VoucherDetail { get; set; }

    }
}
