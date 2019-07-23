namespace ShoppingCart.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int SavePercentage => (int) ((1 - SalePrice / ListPrice) * 100);
        public bool Featured { get; set; }

        public virtual AuthorViewModel Author { get; set; }
        public virtual CategoryViewModel Category { get; set; }

    }
}