using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Please enter role name")]
        public string name { get; set; }
    }
}
