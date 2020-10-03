using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Vouchers = new HashSet<Voucher>();
        }

        [Key]
        [Column("GUID")]
        [StringLength(36)]
        public string Guid { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public int? MaxQty { get; set; }
        public int? MaxGiftQty { get; set; }

        [InverseProperty("CustomerGu")]
        [JsonIgnore]
        public virtual ICollection<Voucher> Vouchers { get; set; }

    }
}
