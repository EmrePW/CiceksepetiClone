using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);
            builder.Property(p => p.ProductID);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();

            builder.HasData(
                new Product() { ProductID = 1, ProductName = "lorem", UnitPrice = 1000, CategoryID = 3, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 800 },
                new Product() { ProductID = 2, ProductName = "ipsum", UnitPrice = 5000, CategoryID = 5, SuperCategory = 2, CompanyID = 1 },
                new Product() { ProductID = 3, ProductName = "dolor", UnitPrice = 400, CategoryID = 4, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 230 },
                new Product() { ProductID = 4, ProductName = "sit", UnitPrice = 400, CategoryID = 5, SuperCategory = 1, CompanyID = 1 },
                new Product() { ProductID = 5, ProductName = "amet", UnitPrice = 400, CategoryID = 4, SuperCategory = 1, CompanyID = 1 },
                new Product() { ProductID = 6, ProductName = "contactour", UnitPrice = 2000, CategoryID = 8, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 1678 },
                new Product() { ProductID = 7, ProductName = "lavender", UnitPrice = 400, CategoryID = 12, SuperCategory = 1, CompanyID = 1 },
                new Product() { ProductID = 8, ProductName = "Test1", UnitPrice = 1255, CategoryID = 11, SuperCategory = 2, CompanyID = 1, DiscountedPrice = 543 },
                new Product() { ProductID = 9, ProductName = "Test2", UnitPrice = 1000, CategoryID = 3, SuperCategory = 2, CompanyID = 1, DiscountedPrice = 856 },
                new Product() { ProductID = 10, ProductName = "Test3", UnitPrice = 543, CategoryID = 3, SuperCategory = 1, CompanyID = 1 },
                new Product() { ProductID = 11, ProductName = "Test4", UnitPrice = 100, CategoryID = 4, SuperCategory = 1, CompanyID = 1 },
                new Product() { ProductID = 12, ProductName = "Test5", UnitPrice = 50, CategoryID = 5, SuperCategory = 2, CompanyID = 1 },
                new Product() { ProductID = 13, ProductName = "Test6", UnitPrice = 40, CategoryID = 4, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 35 },
                new Product() { ProductID = 14, ProductName = "Test7", UnitPrice = 290, CategoryID = 5, SuperCategory = 2, CompanyID = 1 },
                new Product() { ProductID = 15, ProductName = "Test8", UnitPrice = 954, CategoryID = 6, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 825 },
                new Product() { ProductID = 16, ProductName = "CardTest1", UnitPrice = 850, CategoryID = 3, SuperCategory = 1, CompanyID = 1, DiscountedPrice = 250 },
                new Product() { ProductID = 17, ProductName = "CardTest2", UnitPrice = 850, CategoryID = 3, SuperCategory = 1, CompanyID = 1 }
            );
        }
    }
}