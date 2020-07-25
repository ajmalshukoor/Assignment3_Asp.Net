using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolemanagement.Models
{
    public class Booking
    {
        [Key]
        public int BookingNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Room Number")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Check In")]
        public DateTime CheckIn { get; set; }
        [DisplayName("Check Out")]
        public DateTime CheckOut { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("No. of Persons")]
        public int NumberofPersons { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Booking Time")]
        public DateTime BookingTime { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
    }
}
