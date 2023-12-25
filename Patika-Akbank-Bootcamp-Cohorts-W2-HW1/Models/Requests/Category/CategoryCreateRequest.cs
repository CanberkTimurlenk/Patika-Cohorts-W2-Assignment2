using System.ComponentModel.DataAnnotations;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
