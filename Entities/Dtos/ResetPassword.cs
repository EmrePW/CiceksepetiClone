using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPassword
    {
        public String? username { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Old password is required")]
        public String? OldPassword { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "new password is required")]
        public String? NewPassword { get; init; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords must be the same")]

        public String? NewPasswordConfirm { get; init; }
    }
}