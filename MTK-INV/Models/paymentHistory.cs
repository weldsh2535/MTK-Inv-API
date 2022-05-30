using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class paymentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [StringLength(50)]
        public string vocherId { get; set; }
        public int customerId { get; set; }
        public int vendorId { get; set; }
        public int amountPaid { get; set; }
        [StringLength(50)]
        public string paymentStatus { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
        [Required]
        public int balance { get; set; }
    }
}
