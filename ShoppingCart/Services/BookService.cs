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

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}