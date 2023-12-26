using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CiceksepetiApp.Models
{
    public class ProductGetViewModel
    {

        public Product? Product { get; set; }

        public IEnumerable<Rating>? Ratings { get; set; } = Enumerable.Empty<Rating>();

    }
}