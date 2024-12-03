namespace SassoInmobiliariaAPI.Models.Exceptions
{
    public class DuplicateElementException : Exception
    {
        public DuplicateElementException()
        : base()
        {
        }

        public DuplicateElementException(string message)
            : base(message)
        {
        }

        public DuplicateElementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DuplicateElementException(string name, object key)
            : base($"Entity {name} ({key}) already exists.")
        {
        }
    }
}
