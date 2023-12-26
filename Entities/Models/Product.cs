using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }
        [Required]
        public String? ProductName { get; set; } = String.Empty;

        public decimal UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int SuperCategory { get; set; }

        public String? ImageURL { get; set; }

        public int? RatingCount { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public String? Summary { get; set; }

        public bool FreeShip { get; set; }

        public String? MessageCard { get; set; }

        public Category? Category { get; set; }

        public Company? Company { get; set; }
    }
}