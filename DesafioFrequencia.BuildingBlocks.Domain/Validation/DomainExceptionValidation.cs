namespace DesafioFrequencia.Domain.Exceptions
{
    public class DomainExceptionValidation : Exception
    {
        private DomainExceptionValidation(string error) : base(error) { }

        private DomainExceptionValidation() : base()
        {
        }

        public DomainExceptionValidation(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public static void When(bool hasError, string error)
        {
            if(hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
