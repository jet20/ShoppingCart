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
            throw new System.NotImplementedException();
        }

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();
            var list = Mapper.Map<List<BookViewModel>>(books);
            return PartialView(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    
}