namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; }

        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, String? deliverDate, String? deliverTime, String? deliverCity)
        {
            CartLines.Add(new CartLine()
            {
                Product = product,
                DeliverDate = deliverDate,
                DeliverTime = deliverTime,
                DeliverCity = deliverCity
            });
        }

        public virtual void RemoveLine(Product product) => CartLines.RemoveAll(line => line.Product.ProductID.Equals(product.ProductID));

        public virtual void ClearCart()
        {
            CartLines.Clear();
        }
    }
}