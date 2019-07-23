using System.Collections.Generic;

namespace ShoppingCart.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
    }
}