using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Rating
    {
        public long RatingID { get; set; }
        public IdentityUser? Customer { get; set; }

        public Product? Product { get; set; }
        public String? UserID { get; set; }

        public int ProductID { get; set; }

        public DateTime RatedAt { get; set; } = DateTime.Now;

        public bool? IsFavourite { get; set; }

        public String? RatingValue { get; set; }

        public String? Opinion { get; set; }
    }
}