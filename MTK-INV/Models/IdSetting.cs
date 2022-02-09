using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class IdSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int voucherTypeId { get; set; }
        [ForeignKey("voucherTypeId")]
        public virtual Lookup lookup { get; set; }
        [StringLength(50)]
        public string prefix { get; set; }
        public int length { get; set; }
        [StringLength(50)]
        public string suffix { get; set; }
        [StringLength(50)]
        public string currentId { get; set; }
    }
}
