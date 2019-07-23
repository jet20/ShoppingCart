using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShoppingCart.Models;

namespace ShoppingCart.DAL
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 采用单数命名规则
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DataInitialization : DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    {
        protected override void Seed(ShoppingCartContext context)
        {
            var categories = new List<Category>
            {
                new Category {Name = "科技"},
                new Category {Name = "科幻小说"},
                new Category {Name = "人文社科"},
                new Category {Name = "小说"},
            };
            categories.ForEach(c => context.Categories.Add(c));

            var author = new Author
            {
                FirstName = "Martin",
                LastName = "Fowler",
                Biography = "...",
            };
            

            var books = new List<Book>()
            {
                new Book()
                {
                    Author = author,
                    Category = categories[0],
                    Description = "...",
                    Featured = true,
                    ImageUrl = "http://img3m7.ddimg.cn/87/7/27851757-1_u_26.jpg",
                    Isbn = "9787115508652",
                    ListPrice = 99M,
                    SalePrice = 95M,
                    Synopsis = "...",
                    Title = "重构 改善既有代码的设计"
                }
            };

            books.ForEach(b => context.Books.Add(b));

            context.SaveChanges();
        }
    }
}