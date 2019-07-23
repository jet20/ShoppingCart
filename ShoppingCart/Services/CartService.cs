using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CartService
    {
        private ShoppingCartContext _db = new ShoppingCartContext();


        public Cart GetBySessionId(string sessionId)
        {
            var cart = _db.Carts
                .Include(x => x.CartItems)
                .SingleOrDefault(c => c.SessionId == sessionId);

            if (cart == null)
            {
                cart = CreateCart(sessionId);
            }
            return cart;
        }

        private Cart CreateCart(string sessionId)
        {
            var cart = new Cart()
            {
                SessionId = sessionId,
                CartItems = new List<CartItem>(),
            };

            _db.Carts.Add(cart);
            _db.SaveChanges();
            return cart;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}