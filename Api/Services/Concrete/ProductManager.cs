using Microsoft.EntityFrameworkCore;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Contexts;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Exceptions;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Responses.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Concrete
{
    public class ProductManager : IProductService
    {
        // A Product Manager for CRUD operations on Product entities.
        private readonly AppDbContext _context;

        public ProductManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductReadResponse?> GetProductByIdAsync(int id)
        {
            var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                throw new ProductNotFoundException(id: id);

            return new ProductReadResponse { Id = entity.Id, Name = entity.Name, Price = entity.Price, CategoryId = entity.CategoryId };
        }

        public async Task<IEnumerable<ProductReadResponse>> GetAllAsync(string? name, string? orderBy, string? order)
        {
            var products = _context.Products.Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name));

            order = order?.ToLower().Trim();

            switch (orderBy)
            {
                case "name":
                    products = order == "desc" ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name);
                    break;
                case "price":
                    products = order == "desc" ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price);
                    break;

                default:
                    products = products.OrderBy(p => p.Id);
                    break;
            }

            return await products.Select(p =>
                                new ProductReadResponse
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    CategoryId = p.CategoryId
                                })
                                 .ToListAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                throw new ProductNotFoundException(id: id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, ProductUpdateRequest productToUpdate)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
                throw new ProductNotFoundException(id: id);

            entity.Name = productToUpdate.Name;
            entity.Price = productToUpdate.Price;
            entity.CategoryId = productToUpdate.CategoryId;

            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProductAsync(ProductCreateRequest product)
        {
            await _context.Products.AddAsync(new Product { Name = product.Name, Price = product.Price, CategoryId = product.CategoryId });
            await _context.SaveChangesAsync();
        }
    }
}
