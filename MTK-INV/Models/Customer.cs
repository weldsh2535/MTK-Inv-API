using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [StringLength(50)]
        public string fullname { get; set; }
        [StringLength(50)]
        public string phonenumber { get; set; }
        [StringLength(50)]
        public string location { get; set; }
        public int balance { get; set; }
        [StringLength(50)]
        public string address { get; set; }

    }
}
