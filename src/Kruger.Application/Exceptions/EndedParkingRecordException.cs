namespace Kruger.Application.Exceptions
{
    public class EndedParkingRecordException : ValidationErrorException
    {
        public EndedParkingRecordException(string message = "The parking record has already ended")
            : base(message) { }
    }
}
