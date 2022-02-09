using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class VocherStoreTransation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Items items { get; set; }
        [Required]
        [StringLength(50)]
        public string vocherId { get; set; }
        public int fromStoreId { get; set; }
        public int toStoreId { get; set; }
        public double amount { get; set; }
    }
}
