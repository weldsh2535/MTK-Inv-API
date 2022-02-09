using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users user { get; set; }
        [StringLength(500)]
        public string remark { get; set; }
        [Required]
        public int funId { get; set; }
        [ForeignKey("funId")]
        public virtual functionality functionality { get; set; }
    }
}
