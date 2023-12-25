using ECommerceApi.Models.Requests.Product;
using ECommerceApi.Models.Responses.Product;

namespace ECommerceApi.Services.Abstract
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
