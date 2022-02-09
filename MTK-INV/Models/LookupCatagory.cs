using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class LookupCatagory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50000)]
        public string picture { get; set; }
        [StringLength(50)]
        public string remark { get; set; }

    }
}
