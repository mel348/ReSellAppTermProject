using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReSell.Models
{
    public class Trade
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the item you have to trade!")]
        [Display(Name = "Trade Item")]
        [Column("Trade Item")]
        [StringLength(50, MinimumLength = 8)]
        public string TradeItem { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(30, MinimumLength = 5)]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }

        [StringLength(5, ErrorMessage = "Please enter a valid 5 digit zipcode.")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Please describe what you have for trade and what you are willing to take as a trade.")]
        [StringLength(300, MinimumLength = 20)]
        public string Description { get; set; }
      
        public int SellersID { get; set; }
        [Display(Name = "Seller")]
        public Sellers Sellers { get; set; }

    }
}
