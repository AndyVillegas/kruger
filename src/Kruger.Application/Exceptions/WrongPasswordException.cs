namespace Kruger.Application.Exceptions
{
    public class WrongPasswordException : ValidationErrorException
    {
        public string Username { get; set; }

        public WrongPasswordException(string username)
            : base("Wrong password")
        {
            Username = username;
        }
    }
}
