using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ShoppingCart.DAL;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers.Api
{
    public class CartItemsController : ApiController
    {
        private CartItemService _cartItemService = new CartItemService();
        public CartItemViewModel Post(CartItemViewModel cartItem)
        {
            var newCartItem = _cartItemService.AddToCart(Mapper.Map<CartItem>(cartItem));
            return Mapper.Map<CartItemViewModel>(newCartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class CartItemService
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public CartItem GetByCartIdAndBookId(int cartId, int bookId)
        {
            return _db.CartItems.SingleOrDefault(x => x.CartId == cartId && x.BookId == bookId);
        }

        public CartItem AddToCart(CartItem cartItem)
        {
            var existingCartItem = GetByCartIdAndBookId(cartItem.CartId, cartItem.BookId);
            if (existingCartItem == null)
            {
                _db.Entry(cartItem).State = EntityState.Added;
                existingCartItem = cartItem;
            }
            else
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }

            _db.SaveChanges();

            return existingCartItem;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}