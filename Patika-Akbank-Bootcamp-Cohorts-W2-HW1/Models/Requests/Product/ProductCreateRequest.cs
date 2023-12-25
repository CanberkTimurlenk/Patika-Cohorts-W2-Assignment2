using System.ComponentModel.DataAnnotations;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product
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
