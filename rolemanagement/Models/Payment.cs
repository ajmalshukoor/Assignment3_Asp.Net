using rolemanagement.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolemanagement.Models
{
    public class Payment
    {
        [Key]
        public int BillingId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Total Charge")]
        public double TotalCharge { get; set; }
        [DisplayName("Card Number")]
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }
        public Customer Customer { get; set; }

    }
}
