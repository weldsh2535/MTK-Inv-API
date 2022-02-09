using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTK_Inv.Models
{
    public class Vocher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string vocherId { get; set; }
        [Required]
        public double subTotal { get; set; }
        [Required]
        public double taxAmount { get; set; }
        [Required]
        public double grandTotal { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int vocherTypeId { get; set; }
        [ForeignKey("vocherTypeId")]
        public virtual Lookup lookup { get; set; }
        public int vendorId { get; set; }
        public int userId { get; set; }
        [StringLength(50)]
        public string PaymentStatus { get; set; }
    }
     
}
