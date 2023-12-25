using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract;

namespace Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Get product by id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(); // return 404

            return Ok(product); // return 200 + data
        }

        // create product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateRequest product)
        {
            await _productService.CreateProductAsync(product);
            return Created(); // return 201
        }

        // update product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductUpdateRequest productToUpdate)
        {
            await _productService.UpdateProductAsync(id, productToUpdate);
            return NoContent(); // return 204
        }

        // partially update product
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateProductAsync([FromRoute] int id, [FromBody] JsonPatchDocument<ProductUpdateRequest> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest(); // 400

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(); // 404

            var productToPatch = new ProductUpdateRequest { Name = product.Name, CategoryId = product.CategoryId, Price = product.Price };

            patchDoc.ApplyTo(productToPatch);

            await _productService.UpdateProductAsync(id, productToPatch);

            return NoContent(); // 204
        }

        // delete product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent(); // return 204
        }

        // bonus 
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] string? name, [FromQuery] string? orderBy, [FromQuery] string? order)
        {
            var products = await _productService.GetAllAsync(name, orderBy, order);

            if (!products.Any())
                return NotFound(); // return 404

            return Ok(products); // return 200 + data
        }
    }
}