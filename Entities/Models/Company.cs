using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Company
    {
        public String UserID { get; set; } = String.Empty;
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String? CompanyName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Type is required")]
        public String? CompanyType { get; set; } = String.Empty;
        public String? IdNumber { get; set; } = String.Empty;

        public String? SellCategory { get; set; } = String.Empty;

        [Required(ErrorMessage = "Contact name is required")]
        public String? ContactName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "A phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public String? PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Country is required")]
        public String? Country { get; set; } = "Turkey";

        [Required(ErrorMessage = "City is required")]
        public String? City { get; set; } = String.Empty;

        [Required(ErrorMessage = "Line1 is required")]
        public String? Address { get; set; } = String.Empty;

        public String? CompanyTradeType { get; set; }
        [MinLength(16)]
        public String? MERSISNumber { get; set; }

        [Required(ErrorMessage = "Kayıtlı E-Posta hesabı gereklidir.")]
        [DataType(DataType.EmailAddress)]
        public String KEPAddress { get; set; } = String.Empty;

        public String TaxProvince { get; set; } = "Ankara";

        public String? VirtualCompanyName { get; set; }

        public String? DeliveryMethod { get; set; }

        public String? CompanyOwner { get; set; }

        public bool? ApplicationAccepted { get; set; } = false;

        public ICollection<Product>? Products { get; set; }

        public decimal? weeklyProfit { get; set; } = 0;
        public decimal? Profit { get; set; } = 0;
    }
}