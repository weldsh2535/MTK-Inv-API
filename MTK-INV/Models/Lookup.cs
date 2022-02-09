using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Lookup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        public int type { get; set; }
        [ForeignKey("type")]
        public virtual LookupCatagory lookupCategory { get; set; }
        [Required]
        public string value { get; set; }
        [StringLength(50)]
        public string remark { get; set; }
       
    }
}
