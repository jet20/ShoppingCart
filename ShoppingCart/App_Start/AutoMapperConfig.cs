using AutoMapper;
using AutoMapper.Configuration;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile(new ShoppingCartProfile());
            Mapper.Initialize(cfg);
        }
    }

    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<Cart, CartViewModel>();
            CreateMap<CartItem, CartItemViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Book, BookViewModel>();
            CreateMap<Author, AuthorViewModel>();
        }
    }
}