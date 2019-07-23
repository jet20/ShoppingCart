using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService _categoryService = new CategoryService();

        [ChildActionOnly]
        public ActionResult Menu(int selectCategoryId)
        {
            var categories = _categoryService.Get();
            ViewBag.SelectCategoryId = selectCategoryId;

            var list = Mapper.Map<List<CategoryViewModel>>(categories);
            return PartialView(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}