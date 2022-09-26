using AutoMapper;
using WebChuyenDe.Data;
using WebChuyenDe.Data.ViewModel;

namespace WebAppBanHang.Mapping
{
    public static class AutoMap
    {
        public static void MapConfig()
        {
            Mapper.CreateMap<AboutViewModel, About>();
            Mapper.CreateMap<About, AboutViewModel>();

            Mapper.CreateMap<ContactViewModel, Contact>();
            Mapper.CreateMap<Contact, ContactViewModel>();

            Mapper.CreateMap<FeedbackViewModel, Feedback>();
            Mapper.CreateMap<Feedback, FeedbackViewModel>();

            Mapper.CreateMap<MenuTypeViewModel, MenuType>();
            Mapper.CreateMap<MenuType, MenuTypeViewModel>();

            Mapper.CreateMap<MenuVm, Menu>();
            Mapper.CreateMap<Menu, MenuViewModel>();

            Mapper.CreateMap<NewCategoryViewModel, NewCategory>();
            Mapper.CreateMap<NewCategory, NewCategoryViewModel>();

            Mapper.CreateMap<NewViewModel, New>();
            Mapper.CreateMap<New, NewViewModel>();

            Mapper.CreateMap<ProductCategoryViewModel, ProductCategory>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();

            Mapper.CreateMap<ProductVm, Product>();
            Mapper.CreateMap<ProductViewModel,ProductVm>();
            Mapper.CreateMap<Product, ProductViewModel>();

            Mapper.CreateMap<SliderViewModel, Slider>();
            Mapper.CreateMap<Slider, SliderViewModel>();

            Mapper.CreateMap<TagViewModel, Tag>();
            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<User, UserViewModel>();

            Mapper.CreateMap<User, UserLoginViewModel>();

            Mapper.CreateMap<OrderViewModel, Order>();
            Mapper.CreateMap<Order, OrderViewModel>();

            Mapper.CreateMap<OrderDetailVm, OrderDetail>();
            Mapper.CreateMap<OrderDetail, OrderDetailViewModel>();

            Mapper.CreateMap<OrderTemporaryViewModel, OrderTemporary>();
            Mapper.CreateMap<OrderTemporary, OrderTemporaryViewModel>();
        }
    }
}