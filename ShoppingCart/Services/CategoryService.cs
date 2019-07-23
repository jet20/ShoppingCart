using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DAL;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CategoryService
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<Category> Get()
        {
            return _db.Categories.ToList();
        }
    }
}