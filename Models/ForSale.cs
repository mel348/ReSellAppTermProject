using ReSell.Models;
using System.ComponentModel.DataAnnotations;

namespace ReSellApp.Models
{
    public class ForSale
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the item you have for sale!")]
        public string SaleItem { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a valid 6 digit zipcode.")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Enter Details of what you have for sale")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        
        public int SellersID { get; set; }
        public Sellers Sellers { get; set; }

    }
}
