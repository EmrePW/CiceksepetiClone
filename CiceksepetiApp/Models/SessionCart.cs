using System.Text.Json.Serialization;
using Entities.Models;
using CiceksepetiApp.Infrastructure.Extensions;

namespace CiceksepetiApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCurrentCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, String? deliverDate, String? deliverTime, String? deliverCity)
        {
            base.AddItem(product, deliverDate, deliverTime, deliverCity);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session?.Remove("cart");
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart", this);
        }

    }
}