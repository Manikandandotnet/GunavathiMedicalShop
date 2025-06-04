using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class SalesReport
    {
        public int id { get; set; }


        [Required]
        [Display(Name ="Report ID")]
       public string ReportID { get; set; }



        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }



        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }


        [Required]
        [Display(Name = "Total Sales")]

        public string Totalsales {  get; set; }



        [Required]
        [Display(Name = "Average Order Values")]

        public string Avgordervalue { get; set; }



        [Required]
        [Display(Name = "Top Selling Products")]

        public string Topsellproducts { get; set; }

  
    
    
    
    
    }
}