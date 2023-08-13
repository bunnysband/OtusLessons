namespace OtusDbData.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? NickName { get; set; }
        public string? Email { get; set; }
    }
}
