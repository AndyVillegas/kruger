namespace Kruger.Application.Exceptions
{
    public class IdentificationRepeatedException : ValidationErrorException
    {
        public IdentificationRepeatedException(string message = "The Identification is repeated")
            : base(message) { }
    }
}
