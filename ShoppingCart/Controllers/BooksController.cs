using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class BooksController : Controller
    {
        private BookService _bookService = new BookService();

        public ActionResult Index(int categoryId)
        {
            var books = _bookService.GetByCategoryId(categoryId);
            var list = Mapper.Map<List<BookViewModel>>(books);
            return View(list);
        }

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();
            var list = Mapper.Map<List<BookViewModel>>(books);
            return PartialView(list);
        }

        public ActionResult Details(int id)
        {
            var book = _bookService.GetById(id);
            var model = Mapper.Map<BookViewModel>(book);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    
}