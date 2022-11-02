using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReSell.Models
{
    public class GarageSales
    {
        public int ID { get; set; }

        [NotMapped]
        public string PostingTitle { get; set; }

        [Required(ErrorMessage = "Please enter the address where the garage sale is located.")]
        [StringLength(150, MinimumLength = 8)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(150, MinimumLength = 5)]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter the State using 2 characters.")]
        public string State { get; set; }

        [StringLength(5, ErrorMessage = "Please enter your 5-digit zipcode")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Please list what you will have for sale.")]
        [StringLength(1000, ErrorMessage = "Please list items for sale or a description of items for sale.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the date that the garage sale will be happening (mm/dd/yy)")]
        public int Date { get; set; }

        [Required(ErrorMessage = "Please enter the start and end time of the garage sale (ex. 100-200")]
        [Display(Name = "Garage Sale Hours")]
        [Range(100, 1200)]
        public int Time { get; set; }

        public int SellersID { get; set; }
        [Display(Name = "Seller")]

        public Sellers Sellers { get; set; }

    }
}
