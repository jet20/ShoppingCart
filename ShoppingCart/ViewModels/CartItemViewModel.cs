namespace ShoppingCart.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public virtual CartViewModel Cart { get; set; }
        public virtual BookViewModel Book { get; set; }
    }
}