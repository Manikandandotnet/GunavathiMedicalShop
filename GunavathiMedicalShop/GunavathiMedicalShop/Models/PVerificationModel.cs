using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GunavathiMedicalShop.Models
{
    public class PVerificationModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public string PName { get; set; }

        [Display(Name = "Profile")]
        public string PresimagePath { get; set; }

        public HttpPostedFileBase TEMP_PROFILE { get; set; }

        [Required]
        [Display(Name = "Verification Status")]
        public string verifystatus { get; set; }

        public List<SelectListItem> StatusList { get; set; }

        [Required]
        [Display(Name = "Pharmacist Notes")]
        public string pharmacistnotes { get; set; }
    }
}
