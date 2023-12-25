using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models.Requests.Product
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
