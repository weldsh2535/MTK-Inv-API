using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Vendors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string vendorName { get; set; }
        [StringLength(50)]
        public string contact { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string phonenumber { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(50)]
        public string website { get; set; }
        [StringLength(50)]
        public string balance { get; set; }
    }
}
