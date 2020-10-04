using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations.Models
{
    [Table("doctors")]
    public partial class Doctors
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Column("gender")]
        public int Gender { get; set; }
        [Required]
        [Column("specialist")]
        [StringLength(255)]
        public string Specialist { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime Created { get; set; }
    }
}
