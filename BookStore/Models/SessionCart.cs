using BookStore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SessionCart : ShoppingCart
    {
        //create Session property
        [JsonIgnore]
        public ISession Session { get; set; }

        //method for getting shopping cart
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("shoppingCart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("shoppingCart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("shoppingCart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("shoppingCart");
        }
    }
}
