namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id)
            : base($"Category with id {id} not found.")
        {
        }

        public CategoryNotFoundException() : base()
        {
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
        }

        public CategoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}