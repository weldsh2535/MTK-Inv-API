using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class functionality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
         [Required]
        [StringLength(50)]
        public string compName { get; set; }
         [StringLength(500)]
        public string description { get; set; }
         [StringLength(500)]
        public string remark { get; set; }
    }
}
