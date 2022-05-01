using System;

namespace Kruger.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Not found") : base(message)
        {
        }
    }
}
