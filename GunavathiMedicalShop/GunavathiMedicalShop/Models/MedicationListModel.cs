using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class MedicationListModel
    {

        public int id { get; set; }


        [Required]
        [Display(Name ="Product ID")]
      public string ProductID { get; set; }


        [Required]
        [Display(Name = "Name Of the Medicine")]
        public string Name { get; set; }



        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }




        [Required]
        [Display(Name = "Price")]
        public string price { get; set; }



        [Required]
        [Display(Name = "Dosages")]
        public string Dosage { get; set; }



        [Required]
        [Display(Name = "Date Of Expired")]
        public DateTime Expirationdate { get; set; }



       
        [Display(Name = "Profile")]
        public string ImagePath { get; set; }  

        public HttpPostedFileBase TEMP_PROFILE { get; set; }



        [Required]
        [Display(Name = "Brand ID")]
        public string BrandID {  get; set; }



        [Required]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }




        [Required]
        [Display(Name = "Medicine Brand ID")]
        public string MedicationBrandID { get; set; }
        

      



    }
}