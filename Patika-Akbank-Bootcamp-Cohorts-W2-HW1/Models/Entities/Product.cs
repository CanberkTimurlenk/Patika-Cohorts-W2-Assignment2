using System.ComponentModel.DataAnnotations;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
