using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        [ChildActionOnly]
        public ActionResult Menu(int selectCategoryId)
        {
            return PartialView();
        }
    }
}