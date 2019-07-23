using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class BookService
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public List<Book> GetFeatured()
        {
            return _db.Books
                .Include(nameof(Book.Author))
                .Where(x => x.Featured)
                .ToList();
        }

        public List<Book> GetByCategoryId(int categoryId)
        {
            return _db.Books
                .Include(nameof(Book.Author))
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Book GetById(int id)
        {
            return _db.Books.Include(nameof(Book.Author)).SingleOrDefault(x => x.Id == id);
        }
    }
}