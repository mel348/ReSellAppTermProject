using System;
using System.ComponentModel.DataAnnotations;

namespace ReSell.Models
{
    public class Trade
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the item you have to trade!")]
        public string TradeItem { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a valid 6 digit zipcode.")]
        public int Zipcode { get; set; }
        [Required(ErrorMessage = "Please describe what you have for trade and what you are willing to take as a trade.")]
        public string Description { get; set; }
      
        public int SellersID { get; set; }
        public Sellers Sellers { get; set; }

    }
}
