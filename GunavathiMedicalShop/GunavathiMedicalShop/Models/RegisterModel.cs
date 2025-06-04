using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace GunavathiMedicalShop.Models
{
    public class RegisterModel
    {
        [Key]
        public int id {  get; set; }

        [Required]
        [StringLength(20,MinimumLength =3,ErrorMessage ="User name Minimum Length is 3")]
        [Display(Name ="User Name")]
        public string Usernames {  get; set; }

        [Required]
        [Display(Name ="User Type")]
      public string UserType { get; set; }
        public List<SelectListItem> usertypelist { get; set; }


        [Required]
        [Display(Name ="Email ID")]
        [DataType(DataType.EmailAddress)]
      public string Email {  get; set; }

        [Required]
        [Display(Name ="Contact Number")]
        [DataType(DataType.PhoneNumber)]
      public string ContactNo { get; set; }

        [Required]
        [Display(Name ="Address")]
        [StringLength(300)]
        
       public string Addresses {  get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
       public string Passwords { get; set; }


        [Required]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        //[Compare(Passwords,true)]
        public string CPasswords { get; set; }


    }
}