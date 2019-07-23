using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class CartsController : Controller
    {
        private CartService _cartService = new CartService();

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);
            return PartialView(AutoMapper.Mapper.Map<Cart, CartViewModel>(cart));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }

    
}
