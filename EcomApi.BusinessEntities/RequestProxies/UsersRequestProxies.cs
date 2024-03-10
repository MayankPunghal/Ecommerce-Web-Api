using System.ComponentModel.DataAnnotations.Schema;

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
        public int? UserId { get; set; }
    }
    public class GetUserByIdRequestProxy
    {
        public int UserId { get; set; }
    }
    public class SetUserRequestProxy
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
