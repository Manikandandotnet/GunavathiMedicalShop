using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class Prescription
    {
        public int id {  get; set; }


        [Required]
        [Display(Name ="Prescription ID")]
       public string PrescriptionID {  get; set; }


        [Required]
        [Display(Name ="Customer ID")]
        public string CustomerID { get; set; }


        [Required]
        [Display(Name ="Doctor ID")]
        public string DoctorID { get; set; }

        [Required]
        [Display(Name ="Name Of Medicine")]
        public string Medication { get; set; }


        [Required]
        [Display(Name ="Dosage")]
          public string Dosage { get; set; }



        [Required]
        [Display(Name ="Frequency(per-Day)")]
          public string Frequency { get; set; }



        [Required]
        [Display(Name ="Duration")]
          public string Duration { get; set; }




    }
}