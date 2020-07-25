using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolemanagement.Models
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Room Number")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Room Type")]
        public string RoomType { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
        [DisplayName("Number of Beds")]
        public string NumberofBeds { get; set; }

        public Customer Customer { get; set; }
        public IList<Booking> Booking { get; set; }

    }
}
