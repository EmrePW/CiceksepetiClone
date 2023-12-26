using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record CompanyDto : RegisterDto
    {
        public String? UserID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String? CompanyName { get; init; }
        [Required(ErrorMessage = "Type is required")]
        public String? CompanyType { get; init; }
        [Required(ErrorMessage = "Id or Tax number is required")]
        public long? IdNumber { get; init; }
        [Required(ErrorMessage = "We need to know your selling category.")]
        public String? SellCategory { get; init; }
        [Required(ErrorMessage = "We need someones name for contact")]
        public String? ContactName { get; init; }

        [Required(ErrorMessage = "A phone number must be provided")]
        public String? PhoneNumber { get; init; }

        public String? City { get; init; }

        public String Country { get; init; } = "Turkey";
        [Required(ErrorMessage = "Address is required.")]
        public String? Address { get; init; }
        [Required(ErrorMessage = "Trade Type gereklidir.")]
        public String? CompanyTradeType { get; init; }
        [MinLength(16)]
        public String? MERSISNumber { get; init; }

        [Required(ErrorMessage = "Kayıtlı E-Posta hesabı gereklidir.")]
        [DataType(DataType.EmailAddress)]
        public String KEPAddress { get; init; } = String.Empty;
        [Required(ErrorMessage = "Vergi ili gereklidir.")]
        public String TaxProvince { get; init; } = String.Empty;
        [Required(ErrorMessage = "Mağaza ismi gereklidir.")]
        public String VirtualCompanyName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Teslim Yöntemi gereklidir.")]
        public String DeliveryMethod { get; init; } = String.Empty;
        [Required(ErrorMessage = "Who are you?")]
        public String CompanyOwner { get; init; } = String.Empty;
    }
}