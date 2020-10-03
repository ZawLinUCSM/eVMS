using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Vouchers = new HashSet<Voucher>();
        }

        [Required]
        [Column("GUID")]
        [StringLength(36)]
        public string Guid { get; set; }
        [Key]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        [JsonIgnore]
        [InverseProperty("PaymentTypeNavigation")]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
