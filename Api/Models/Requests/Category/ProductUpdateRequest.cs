using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models.Requests.Category
{
    public class CategoryUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
