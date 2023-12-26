using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Order
    {
        public long OrderID { get; set; }
        public IdentityUser? Customer { get; set; }
        public Company? Company { get; set; }
        public Shipper? Shipper { get; set; }

        public ICollection<CartLine> Items { get; set; } = new List<CartLine>();

        public int trackingNumber { get; set; } = RandomNumberGenerator.GetInt32(Int32.MaxValue);

        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        public String? ReceiverName { get; set; } = String.Empty;


        [Required(ErrorMessage = "A phone number needs to be provided.")]
        [DataType(DataType.PhoneNumber)]
        public String? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Address is required so we can find your house.")]
        public String? Line1 { get; set; }


        [Required(ErrorMessage = "City cannot be left blank.")]
        public String? City { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "You must select an Invoice type.")]
        public String? InvoiceType { get; set; }

        public String? InvoiceAddress { get; set; }


        [Required(ErrorMessage = "Card Number is required.")]
        [DataType(DataType.CreditCard)]
        public String? CardNumber { get; set; }

        [Required(ErrorMessage = "Month is required.")]
        public String? CardExpirationMonth { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        public String? CardExpirationYear { get; set; }

        [Required(ErrorMessage = "CVC is required.")]
        public int CardCVC { get; set; }

        public bool Received { get; set; } = true;
        public bool Accepted { get; set; } = false;
        public bool Shipped { get; set; } = false;
        public bool Completed { get; set; } = false;
    }
}