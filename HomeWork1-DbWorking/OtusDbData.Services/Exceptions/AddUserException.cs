namespace OtusDbData.Services.Exceptions
{
    public class AddUserException : Exception
    {
        public AddUserException() : base()
        {
        }
        public AddUserException(string? message) : base(message)
        {
        }
    }
}
