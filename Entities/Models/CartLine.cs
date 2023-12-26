using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Entities.Models
{
    public class CartLine
    {
        public int CartlineID { get; set; }

        public String? DeliverDate { get; set; } = String.Empty;

        public String? DeliverTime { get; set; } = String.Empty;

        public String? DeliverCity { get; set; } = String.Empty;

        public Product Product { get; set; } = new();
        public Company? Company { get; set; }

        public bool? IsAccepted { get; set; } = true;

        public bool? IsReady { get; set; } = false;

        public bool? IsShipped { get; set; } = false;

        public bool IsCompleted { get; set; } = false;
    }
}