using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class StockAdjustment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [StringLength(50)]
        public string transactionType { get; set; }
        [StringLength(50)]
        public string transactionNumber { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        [Required]
        public int store { get; set; }
        [ForeignKey("store")]
        public virtual Lookup lookup { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAfter { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
