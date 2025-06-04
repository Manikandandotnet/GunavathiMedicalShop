using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class DrugHealthInfoModel
    {
        public int id { get; set; }



        [Required]
        [Display(Name ="Name Of The Medication")]
       public string Medication { get; set; }



        [Required]
        [Display(Name = "Usage Of Instruction")]
        public string Usageinstructions {  get; set; }




        [Required]
        [Display(Name = "Side Effects")]
        public string Sideeffects { get; set; }




        [Required]
        [Display(Name = "Interactions")]
        public string Interactions { get; set; }


    }
}