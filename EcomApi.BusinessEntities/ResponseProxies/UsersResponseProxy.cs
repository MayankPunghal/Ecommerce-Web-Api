using EcomApi.DataEntities.Models;

namespace EcomApi.BusinessEntities.ResponseProxies
{
    public class GetUserResponseProxy
    {
        public GetUserResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }

        public List<Users> UsersList { get; set; }
    }
    public class GetUserByIdResponseProxy
    {
        public GetUserByIdResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }

        public Users UserData { get; set; }
    }
    public class SetUserResponseProxy
    {
        public SetUserResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
    }
    public class LoginResponseProxy
    {
        public LoginResponseProxy()
        {
            status = 0;
            requestTime = DateTime.UtcNow;
        }
        public int status { get; set; }
        public string message { get; set; }
        public DateTime requestTime { get; set; }
        public DateTime responseTime { get; set; }
        public string? token { get; set; }
        public UserWithoutPassword user { get; set; }
    }
    public class UserWithoutPassword
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsLocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageName { get; set; }
        public DateTime LastLogin {  get; set; } 
    }

}
