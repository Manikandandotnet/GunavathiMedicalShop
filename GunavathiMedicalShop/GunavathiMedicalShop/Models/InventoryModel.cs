using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class InventoryModel
    {
        [Key]
        public int id {  get; set; }



        [Required]
        [Display(Name ="Stock Level")]
       public string  Stocklevels {  get; set; }



        [Required]
        [Display(Name = "Record Points")]
        public string Reorderpoints { get; set; }



        [Required]
        [Display(Name = "Supplier Information")]
        public string SupplierInfo { get; set; }



        [Required]
        [Display(Name = "Batch Number")]
        public string BatchNo { get; set; }




    }
}