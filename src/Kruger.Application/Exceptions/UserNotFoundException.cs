namespace Kruger.Application.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public string Username { get; set; }

        public UserNotFoundException(string username)
            : base("User not found")
        {
            Username = username;
        }
    }
}
