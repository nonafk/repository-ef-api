namespace Repository_EF_Api.DTOs.User
{
    public class UserResponse
    {
        public int? Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;

        public static UserResponse FromUser(Repository_EF_Api.Models.User user)
        {
            return new UserResponse
            {
                Id = user?.Id,
                Username = user.Username,
                Password = user.Password,
                Level = user.Level,
            };
        }
    }
}
