namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? subCategory { get; set; }
        public decimal MinPrice { get; set; } = 0;

        public decimal MaxPrice { get; set; } = int.MaxValue;

        public bool IsValidPrice => MaxPrice > MinPrice; // true or false
    }
}