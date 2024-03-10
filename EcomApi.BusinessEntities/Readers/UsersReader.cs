using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.DataEntities;
using EcomApi.DataEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EcomApi.BusinessEntities.Readers
{
    public class UsersReader
    {
        EcomContext Context = new EcomContext();
        public List<Users> GetUsersList()
        {
            List<Users> users = new List<Users>();
            users = (from u in Context.Users.AsNoTracking()
                     select u).ToList();
            return users;

        }
        public Users GetUserById(int UserId)
        {
            Users users = new Users();
            users = (from u in Context.Users
                     where u.UserID == UserId
                     select u).FirstOrDefault();
            return users;

        }
        public bool CheckIfUserExist(string UserEmail, string UserName)
        {
            bool check = false;
            check = (from u in Context.Users
                     where u.Email == UserEmail || u.UserName == UserName
                     select true).FirstOrDefault();
            return check;
        }
        public UserWithoutPassword MapUserToUserWithoutPassword(Users user)
        {
            var LastLogin = Context.UserLoginAttempts.FirstOrDefault(a => a.UserID == user.UserID).AttemptDateTime;
            return new UserWithoutPassword
            {
                UserId = user.UserID,
                UserName = user.UserName,
                UserEmail = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsLocked = user.IsLocked,
                RoleId = user.RoleId,
                LastLogin = LastLogin,
                ImageName = user.ImageName,
                RoleName = GetRoleNameByUserName(user.UserName)
            };
        }
        public Users GetUserByUserName(string UserName)
        {
            Users user = new Users();
            user = Context.Users.FirstOrDefault(x => x.UserName == UserName);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public Users GetUserByEmail(string UserEmail)
        {
            Users user = new Users();
            user = Context.Users.FirstOrDefault(x => x.Email == UserEmail);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public string GetRoleNameByUserName(string UserName)
        {
            string roleName = "";
            var roleId = Context.Users.FirstOrDefault(x => x.UserName == UserName).RoleId;
            roleName = Context.Roles.FirstOrDefault(x => x.RoleId == roleId).RoleName;
            return roleName;
        }

    }
}
