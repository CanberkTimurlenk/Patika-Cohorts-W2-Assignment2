using System.Text.Json;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
