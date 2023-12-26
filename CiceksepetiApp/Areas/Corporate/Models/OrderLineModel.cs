using Entities.Models;

namespace CiceksepetiApp.Areas.Corporate.Models
{
    public class OrderLineModel
    {
        public CartLine? line { get; set; }
        public Order? order { get; set; }
    }
}