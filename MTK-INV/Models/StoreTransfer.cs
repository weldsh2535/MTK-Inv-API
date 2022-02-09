using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class StoreTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        [StringLength(50)]
        public string storeTransferId { get; set; }
        public DateTime date { get; set; }
        public int quantity { get; set; }
        [Required]
        public int toStoreId { get; set; }
        [ForeignKey("toStoreId")]
        public virtual Lookup lookupToStoreId { get; set; }
        [Required]
        public int fromStoreId { get; set; }
        [ForeignKey("fromStoreId")]
        public virtual Lookup lookupFromStoreId { get; set; }
        [StringLength(50)]
        public string AssignTo { get; set; }
    }
}
