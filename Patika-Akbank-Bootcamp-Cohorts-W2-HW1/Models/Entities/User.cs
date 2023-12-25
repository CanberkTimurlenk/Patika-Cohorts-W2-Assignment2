using System.ComponentModel.DataAnnotations.Schema;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities
{
    [NotMapped]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
