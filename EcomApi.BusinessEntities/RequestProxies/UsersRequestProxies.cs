namespace EcomApi.BusinessEntities.RequestProxies
{
    public class LoginByUserNameRequestProxies
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginByEmailRequestProxies
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
    public class GetUserRequestProxy
    {
        public Guid? Token { get; set; }
        public int? UserId { get; set; }
    }
    public class GetUserByIdRequestProxy
    {
        public Guid? Token { get; set; }
        public int UserId { get; set; }
    }
    public class SetUserRequestProxy
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
