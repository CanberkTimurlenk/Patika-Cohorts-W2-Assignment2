using ECommerceApi.Models.Requests.Category;
using ECommerceApi.Models.Responses.Category;

namespace ECommerceApi.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryReadResponse?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryReadResponse>> GetAllAsync();
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, CategoryUpdateRequest category);
        Task CreateCategoryAsync(CategoryCreateRequest category);
    }
}
