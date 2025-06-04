using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GunavathiMedicalShop.Models
{
    public class CallBackRequestModel
    {

        public int id { get; set; }



        [Required]
        [Display(Name ="Name")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name Should Be 3 characters Above!")]
        public string Name { get; set; }




        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber {get; set;}




        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}



        [Required]
        [Display(Name = "Name Of The Medicine")]
        public string Selectmedicine { get; set;}




        [Required]
        [Display(Name = "Message")]
     
        public string Message { get; set;}


    }
}