namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
