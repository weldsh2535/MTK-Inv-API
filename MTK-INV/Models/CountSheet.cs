using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class CountSheet
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
        public string sheetNo { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int countQty { get; set; }
        [Required]
        public int storeId { get; set; }
        [ForeignKey("storeId")]
        public virtual Lookup lookup { get; set; }
        public int systemQty { get; set; }
        public int differenceQty { get; set; }
    }
}
