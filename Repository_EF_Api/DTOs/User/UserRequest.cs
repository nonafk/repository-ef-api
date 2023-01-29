namespace Repository_EF_Api.DTOs.User
{
    public class UserRequest
    {
        public int? Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}
