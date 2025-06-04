using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GunavathiMedicalShop.Models
{
    public class OrderModel
    {
        public int id { get; set; }


        [Required]
        [Display(Name ="Order ID")]
       public string  OrderID { get; set; }




        [Required]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }


        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Orderdate { get; set; }


        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
        public List<SelectListItem> statusList { get; set; }



        [Required]
        [Display(Name = "Payment Method")]
        public string Paymentmethod { get; set; }


        [Required]
        [Display(Name = "Total Amount")]
        public float Totalamount { get; set; }




    }
}