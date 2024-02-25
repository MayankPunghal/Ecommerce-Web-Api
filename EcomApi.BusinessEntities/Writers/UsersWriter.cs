using EcomApi.DataEntities.Models;
using EcomApi.Utils;
using EcomApi.Utils.Common;


namespace EcomApi.BusinessEntities.Writers
{
    public class UsersWriter
    {
        EcomContext Context = new EcomContext();
        public void SetUser(Users u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }
        public void UpdateUserSuccessfulLoginAttempt(int UserId)
        {
            var userLoginAttempt = Context.UserLoginAttempts.FirstOrDefault(x => x.UserID == UserId);
            if(userLoginAttempt == null)
            {
                var newLoginAttempt = new UserLoginAttempts
                {
                    IsSuccessful = true,
                    UserID = UserId,
                    AttemptCount = 0,
                    AttemptDateTime = DateTime.UtcNow
                };
                Context.UserLoginAttempts.Add(newLoginAttempt);
            }
            else
            {
                userLoginAttempt.IsSuccessful = true;
                userLoginAttempt.AttemptDateTime = DateTime.UtcNow;
                userLoginAttempt.AttemptCount = 0;
                Context.UserLoginAttempts.Update(userLoginAttempt);
            }

            var user = Context.Users.FirstOrDefault(x => x.UserID == UserId);
            user.IsLocked = false;
            Context.Users.Update(user);
            Context.SaveChanges();
        }
        public void UpdateUserFailedLoginAttempt(int UserId)
        {
            var userLoginAttempt = Context.UserLoginAttempts.FirstOrDefault(x => x.UserID == UserId);
            if (userLoginAttempt == null)
            {
                var newLoginAttempt = new UserLoginAttempts
                {
                    IsSuccessful = false,
                    UserID = UserId,
                    AttemptCount = 1,
                    AttemptDateTime = DateTime.UtcNow
                };
                Context.UserLoginAttempts.Add(newLoginAttempt);
            }
            else
            {
                userLoginAttempt.IsSuccessful = false;
                userLoginAttempt.AttemptDateTime = DateTime.UtcNow;
                userLoginAttempt.AttemptCount += 1;
                Context.UserLoginAttempts.Update(userLoginAttempt);
                if (userLoginAttempt.AttemptCount > 3)
                {
                    var user = Context.Users.FirstOrDefault(x => x.UserID == UserId);
                    user.IsLocked = true;
                    Context.Users.Update(user);
                }
            }
            Context.SaveChanges();
        }
    }
}
