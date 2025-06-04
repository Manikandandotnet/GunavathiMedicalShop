using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class InventoryReportModel
    {
        [Key]
        public int id {  get; set; }

        [Required]
        [Display(Name ="Stock Level")]
        public string Stocklevels { get; set; }


        [Required]
        [Display(Name ="Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Expirationdates { get; set; }


        [Required]
        [Display(Name ="Re-Order Points")]
        public string Reorderpoints { get; set; }

    }
}