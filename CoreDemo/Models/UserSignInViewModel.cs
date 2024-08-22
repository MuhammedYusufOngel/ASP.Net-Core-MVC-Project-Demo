using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string? username { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter password")]
        public string? password { get; set; }
    }
}
