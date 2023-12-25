using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models.Entities
{
    [NotMapped]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
