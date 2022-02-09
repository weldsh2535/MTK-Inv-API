using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class LineItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string vocherId { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        public int Quantity { get; set; }
        public decimal taxAmount { get; set; }
        public decimal cost { get; set; }
        public decimal Price { get; set; }
        public decimal subTotal { get; set; }
    }
}
