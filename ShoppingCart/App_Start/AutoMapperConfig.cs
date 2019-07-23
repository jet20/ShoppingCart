using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
            });
        }
    }
}