using ECommerceApi.Services.Abstract;
using ECommerceApi.Services.Concrete;

namespace ECommerceApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();

            return services;
        }

    }
}
