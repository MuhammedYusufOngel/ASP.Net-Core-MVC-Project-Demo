using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Please enter name surname")]
        public string? nameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }

        [Display(Name = "Password Again")]
        [Compare("Password", ErrorMessage ="Password is not same with other password")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please enter mail")]
        public string? Mail { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string? Username { get; set; }
    }
}
