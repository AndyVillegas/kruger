using System;

namespace Kruger.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string message = "Validation error")
            : base(message) { }
    }
}
