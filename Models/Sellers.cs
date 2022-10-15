using System.ComponentModel.DataAnnotations;

namespace ReSell.Models
{
    public class Sellers
    {
        public int ID { get; set; }
        [StringLength(200, ErrorMessage = "Please enter your full name using 30 characters or less.")]
        public string Name { get; set; }
        [StringLength(10, ErrorMessage ="Please enter your zipcode.")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }
        [StringLength(10, ErrorMessage = "Please enter your zipcode")]
        public string Zipcode { get; set; }
        [StringLength(100, ErrorMessage ="Please enter your email address")]
        public string Email { get; set; }

    }
}
