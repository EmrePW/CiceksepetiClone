using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public String? userName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public String? userPassword { get; set; }
    }
}