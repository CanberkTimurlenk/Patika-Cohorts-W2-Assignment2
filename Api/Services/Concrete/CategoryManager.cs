using Microsoft.EntityFrameworkCore;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Contexts;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Exceptions;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Responses.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        // A Category Manager for CRUD operations on Category entities.
        private readonly AppDbContext _context;

        public CategoryManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryReadResponse?> GetCategoryByIdAsync(int id)
        {

            var category = await _context.Categories
                                 .AsNoTracking()
                                 .Where(c => c.Id == id)
                                 .Select(c => new CategoryReadResponse
                                 {
                                     Id = c.Id,
                                     Name = c.Name,
                                     Description = c.Description
                                 })
                                 .FirstOrDefaultAsync();

            if (category == null)
                throw new CategoryNotFoundException(id: id);


            return category;

        }

        public async Task<IEnumerable<CategoryReadResponse>> GetAllAsync()
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .Select(c => new CategoryReadResponse
                                 {
                                     Id = c.Id,
                                     Name = c.Name,
                                     Description = c.Description
                                 })
                                 .ToListAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
                throw new CategoryNotFoundException(id: id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(int id, CategoryUpdateRequest categoryToUpdate)
        {
            var entity = await _context.Categories.FindAsync(id);

            if (entity == null)
                throw new CategoryNotFoundException(id: id);

            entity.Name = categoryToUpdate.Name;
            entity.Description = categoryToUpdate.Description;

            await _context.SaveChangesAsync();
        }

        public async Task CreateCategoryAsync(CategoryCreateRequest categoryToCreate)
        {
            var entity = new Category
            {
                Name = categoryToCreate.Name,
                Description = categoryToCreate.Description
            };

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
