using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string balance { get; set; }
        [StringLength(50)]
        public string location { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        [StringLength(50)]
        public string agreement { get; set; }
        public double commission { get; set; }
    }
}
