using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class AddStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        public int NewQuantity { get; set; }
        [StringLength(50)]
        public string addStockNo { get; set; }
        public DateTime date { get; set; }
        [StringLength(50)]
        public string location { get; set; }
        public int OldQuantity { get; set; }
    }
}
