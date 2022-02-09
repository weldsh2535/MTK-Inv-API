using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class ItemCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string categoryName { get; set; }
        [StringLength(5000)]
        public string description { get; set; }
        [StringLength(5000000)]
        public string picture { get; set; }
        [StringLength(50)]
        public string parentcategory { get; set; }
    }
}
