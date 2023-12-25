using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Responses.Product;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract
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
