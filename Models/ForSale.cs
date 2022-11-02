using System;
using ReSell.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ReSellApp.Models
{
    public class ForSale
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the item you have for sale!")]
        [Display(Name = "Sale Item")]
        [Column("Sale Item")]
        [StringLength(50, MinimumLength = 8)]
        public string SaleItem { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(30, MinimumLength = 5)]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }

        [StringLength(5, ErrorMessage = "Please enter a valid 5 digit zipcode.")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Range(5, 1000000)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Enter Details of what you have for sale")]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        
        public int SellersID { get; set; }
        [Display(Name = "Seller")]
        public Sellers Sellers { get; set; }

    }
}
