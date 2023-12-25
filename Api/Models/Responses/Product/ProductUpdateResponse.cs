using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models.Responses.Product
{
    public class ProductUpdateResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
