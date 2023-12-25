using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models.Requests.Category
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
