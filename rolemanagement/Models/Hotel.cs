using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolemanagement.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Hotel Name")]
        public string HotelName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
