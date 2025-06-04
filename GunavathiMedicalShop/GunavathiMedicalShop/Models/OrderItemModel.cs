using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class OrderItemModel
    {

        public int id {  get; set; }


        [Key]
        [Required]
        [Display(Name ="Order ID")]
        public string OrderID { get; set; }


        
        [Required]
        [Display(Name = "Product ID")]
        public string ProductID { get; set; }


        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }



    }
}