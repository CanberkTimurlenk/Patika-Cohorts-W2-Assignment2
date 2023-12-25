using System.ComponentModel.DataAnnotations;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Responses.Product
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
