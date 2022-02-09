using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string AmaricName { get; set; }
        [Required]
        public double price { get; set; }
        public double cost { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int CatagoryId { get; set; }
        [ForeignKey("CatagoryId")]
        public virtual ItemCategory itemCategory { get; set; }
        [StringLength(5000)]
        public string discrption { get; set; }
         [StringLength(5000000)]
        public string picture { get; set; }
        [Required]
        [StringLength(50)]
        public string type { get; set; }
         [Required]
        public int storeid { get; set; }
        [ForeignKey("storeid")]
        public virtual Lookup lookup { get; set; }
        [StringLength(50)]
        public string brand { get; set; }
        [StringLength(5000)]
        public string remark { get; set; }
    }
}
