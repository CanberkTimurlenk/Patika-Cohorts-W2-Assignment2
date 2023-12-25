using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Concrete;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Extensions
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
