using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using WebChuyenDe.Data;
using WebChuyenDe.Enforcement;
using WebChuyenDe.Service;
using WebChuyenDen.Interface;
using WebClinet.Models;

namespace WebAppBanHang.DI
{
    public static class DependencyInjection
    {
        public static void ConfigAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<ShoppingCartEntities>().AsSelf().InstancePerRequest();

            builder.RegisterType<ModelData>().As<IModelData>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            // Repositories
            builder.RegisterAssemblyTypes(typeof(MenuRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MenuTypeRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NewCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NewRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(SliderRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(TagRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OrderRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(OrderDetailRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OrderTemporaryRepository).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(MenuService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(MenuTypeService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(NewCategoryService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(NewService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductCategoryService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(SliderService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TagService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OrderService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OrderDetaiService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OrderTemporaryService).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}