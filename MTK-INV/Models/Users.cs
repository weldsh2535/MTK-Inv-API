using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public string phonenumber { get; set; }
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string type { get; set; }
        public DateTime registeredAt { get; set; }
    }
}
