using System.IO.Compression;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryID);
            builder.Property(c => c.CategoryName).IsRequired();
            builder.Property(c => c.SuperCategory).IsRequired();

            builder.HasData(
                new Category() { CategoryID = 1, CategoryName = "Flower", SuperCategory = 0 },
                new Category() { CategoryID = 3, CategoryName = "Fresh Flowers", SuperCategory = 1 },
                new Category() { CategoryID = 4, CategoryName = "Potted Flowers", SuperCategory = 1 },
                new Category() { CategoryID = 5, CategoryName = "Bouqets", SuperCategory = 1 },
                new Category() { CategoryID = 6, CategoryName = "Daisies", SuperCategory = 1 },
                new Category() { CategoryID = 7, CategoryName = "Orchids", SuperCategory = 1 },
                new Category() { CategoryID = 8, CategoryName = "Lilliums", SuperCategory = 1 },
                new Category() { CategoryID = 9, CategoryName = "Bonsai", SuperCategory = 1 },
                new Category() { CategoryID = 10, CategoryName = "Lavender", SuperCategory = 1 },
                new Category() { CategoryID = 11, CategoryName = "bruh", SuperCategory = 1 },

                new Category() { CategoryID = 2, CategoryName = "Bonnyfood", SuperCategory = 0 },
                new Category() { CategoryID = 12, CategoryName = "Cakes & Cookies", SuperCategory = 2 },
                new Category() { CategoryID = 13, CategoryName = "Chocolate", SuperCategory = 2 },
                new Category() { CategoryID = 14, CategoryName = "Lotus", SuperCategory = 2 },
                new Category() { CategoryID = 15, CategoryName = "Oreo", SuperCategory = 2 },
                new Category() { CategoryID = 16, CategoryName = "Kitkat", SuperCategory = 2 }
            );
        }
    }
}