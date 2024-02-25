﻿using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.DataEntities;
using EcomApi.DataEntities.Models;
using Microsoft.IdentityModel.Tokens;

namespace EcomApi.BusinessEntities.Readers
{
    public class UsersReader
    {
        EcomContext Context = new EcomContext();
        public List<Users> GetUsersList()
        {
            List<Users> users = new List<Users>();
            users = (from u in Context.Users
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
            return new UserWithoutPassword
            {
                UserId = user.UserID,
                UserName = user.UserName,
                UserEmail = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsLocked = user.IsLocked,
                IsAdmin = user.IsAdmin


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

    }
}
