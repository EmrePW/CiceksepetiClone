namespace Entities.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public String? CategoryName { get; set; }
        public int SuperCategory { get; set; }

        public ICollection<Product>? Products { get; }

    }
}