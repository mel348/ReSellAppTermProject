using System;
using System.ComponentModel.DataAnnotations;

namespace ReSell.Models
{
    public class GarageSales
    {
        public int ID { get; set; }

        [Display(Name = "Title")]
        public string PostingTitle { get; set; }
        [Required(ErrorMessage = "Please enter the address where the garage sale is located.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }
        public int Zipcode { get; set; }
        [Required(ErrorMessage = "Please list what will have for sale.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the date that the garage sale will be happening (mm/dd/yy)")]
        public int Date { get; set; }
        [Required(ErrorMessage = "Please enter the start and end time of the garage sale (ex. 100-200")]
        [Display(Name = "Garage Sale Hours")]
        public int Time { get; set; }

        public int SellersID { get; set; }
        [Display(Name = "Seller")]

        public Sellers Sellers { get; set; }

    }
}
