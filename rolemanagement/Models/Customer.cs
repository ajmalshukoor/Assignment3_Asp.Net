using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rolemanagement.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Street Name")]
        public string StreetName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public IList<Room> Room { get; set; }
        public IList<Booking> Booking { get; set; }
        public IList<Payment> Payment { get; set; }
    }
}
