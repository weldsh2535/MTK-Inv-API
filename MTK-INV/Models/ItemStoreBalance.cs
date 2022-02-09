using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class ItemStoreBalance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        public int beginingQuantity { get; set; }
        public int currentQuantity { get; set; }
        [Required]
        public int storeId { get; set; }
        [ForeignKey("storeId")]
        public virtual Lookup lookup { get; set; }
    }
}
