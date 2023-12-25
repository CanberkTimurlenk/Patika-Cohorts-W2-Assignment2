using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Responses.Product;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductReadResponse?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductReadResponse>> GetAllAsync(string? name, string? orderBy, string? order);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(int id, ProductUpdateRequest product);
        Task CreateProductAsync(ProductCreateRequest product);
    }
}
