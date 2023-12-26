using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductID { get; init; }
        public int? CategoryID { get; init; }
        public int? SuperCategory { get; set; }
        public int? CompanyID { get; set; }

        [Required(ErrorMessage = "A name is required")]
        public String? ProductName { get; init; } = String.Empty;

        [Required(ErrorMessage = "Price is required.")]
        public decimal? UnitPrice { get; init; }
        public String? ImageURL { get; set; }

        public String? Summary { get; init; }
    }
}