namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id)
            : base($"Product with id {id} not found.")
        {
        }

        public ProductNotFoundException(string? message) : base(message)
        {
        }

        public ProductNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ProductNotFoundException()
        {
        }
    }
}
