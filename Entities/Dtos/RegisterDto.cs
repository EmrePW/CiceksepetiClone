using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "username is required")]
        public String? username { get; init; }
        [Required(ErrorMessage = "email is required")]
        public String? Email { get; init; }
        [Required(ErrorMessage = "password is required")]
        public String? Password { get; init; }
    }
}