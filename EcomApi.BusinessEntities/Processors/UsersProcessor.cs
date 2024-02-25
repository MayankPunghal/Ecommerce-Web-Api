using EcomApi.BusinessEntities.Readers;
using EcomApi.BusinessEntities.RequestProxies;
using EcomApi.BusinessEntities.ResponseProxies;
using EcomApi.BusinessEntities.Writers;
using EcomApi.DataEntities.Models;
using EcomApi.Utils.Common;
using System.Diagnostics.Eventing.Reader;

namespace EcomApi.BusinessEntities.Processors
{
    public class UsersProcessor
    {
        private DateTime DtNow { get; set; }


        UsersReader reader = new UsersReader();
        UsersWriter writer = new UsersWriter();

        public UsersProcessor()
        {
            DtNow = DateTime.UtcNow;
        }

        public GetUserResponseProxy GetUsersData(GetUserRequestProxy req)
        {
            Log.Info($"GetUsersData Method call started @{DateTime.UtcNow:O}");
            GetUserResponseProxy response = new GetUserResponseProxy();
            try
            {
                response.UsersList = reader.GetUsersList();

                response.status = 1;
                response.message = "User List Got Successfully";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetUsersData : {ex}");
            }
            finally
            {
                Log.Info($"GetUsersData Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public GetUserByIdResponseProxy GetUserDataById(GetUserByIdRequestProxy req)
        {
            Log.Info($"GetUserDataById Method call started @{DateTime.UtcNow:O}");
            GetUserByIdResponseProxy response = new GetUserByIdResponseProxy();
            try
            {
                response.UserData = reader.GetUserById(req.UserId);

                response.status = 1;
                response.message = $"User Data Got Successfully for UserId : {req.UserId}";
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GetUserDataById : {ex}");
            }
            finally
            {
                Log.Info($"GetUserDataById Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public SetUserResponseProxy RegisterUser(SetUserRequestProxy req)
        {
            Log.Info($"SetUser Method call started @{DateTime.UtcNow:O}");
            SetUserResponseProxy response = new SetUserResponseProxy();
            try
            {
                //check if user already exist based on UserName and Email
                if(!reader.CheckIfUserExist(req.UserEmail, req.UserName))
                {
                    Users user = new Users();
                    user.UserName = req.UserName;
                    user.RoleId = req.RoleId;
                    user.Email = req.UserEmail;
                    user.IsLocked = false;
                    user.FirstName = req.FirstName;
                    user.LastName = req.LastName;
                    user.PasswordHash = PasswordUtils.HashPassword(req.Password);

                    writer.SetUser(user);

                    response.status = 1;
                    response.message = $"User Got Successfully Created for User : {req.UserName} | {req.UserEmail}";
                }
                else
                {
                    response.status = 0;
                    response.message = $"User Name or Email already registered : {req.UserName} | {req.UserEmail}";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in SetUser : {ex}");
            }
            finally
            {
                Log.Info($"SetUser Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public LoginResponseProxy LoginByUserName(LoginByUserNameRequestProxies req)
        {
            Log.Info($"Login Method call started @{DateTime.UtcNow:O}");
            LoginResponseProxy response = new LoginResponseProxy();
            try
            {
                //Get User by Name/Email
                var user = reader.GetUserByUserName(req.UserName);
                if(user == null)
                {
                    //Set the response Model
                    response.user = null;
                    response.status = -1;
                    response.message = $"User doesnt exist for UserName : {req.UserName}";
                }
                else if(user.IsLocked == true)
                {
                    //Set the response Model
                    response.user = null;
                    response.status = -1;
                    response.message = $"User : {req.UserName} is Locked. Please contact Administrator to get it unlocked";
                }
                else
                {
                    //Verify Password
                    if (PasswordUtils.VerifyPassword(req.Password, user.PasswordHash))
                    {
                        //Write this in UserLoginAttempt
                        writer.UpdateUserSuccessfulLoginAttempt(user.UserID);
                        //Set the response Model
                        response.user = reader.MapUserToUserWithoutPassword(user);
                        response.status = 1;
                        response.message = $"Login Successful for User : {req.UserName}";
                    }
                    else
                    {
                        //Write this in UserLoginAttempt
                        writer.UpdateUserFailedLoginAttempt(user.UserID);
                        response.user = null;
                        response.status = 0;
                        response.message = $"Login Unsuccessful. Wrong Password for UserName : {req.UserName}";
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error($"Error in Login : {ex}");
            }
            finally
            {
                Log.Info($"Login Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
        public LoginResponseProxy LoginByEmail(LoginByEmailRequestProxies req)
        {
            Log.Info($"Login Method call started @{DateTime.UtcNow:O}");
            LoginResponseProxy response = new LoginResponseProxy();
            try
            {
                //Get User by Name/Email
                var user = reader.GetUserByEmail(req.UserEmail);
                if(user == null)
                {
                    //Set the response Model
                    response.user = null;
                    response.status = -1;
                    response.message = $"User doesnt exist for Email : {req.UserEmail}";
                }
                else if (user.IsLocked == true)
                {
                    //Set the response Model
                    response.user = null;
                    response.status = -1;
                    response.message = $"User : {req.UserEmail} is Locked. Please contact Administrator to get it unlocked";
                }
                else
                {
                    //Verify Password
                    if (PasswordUtils.VerifyPassword(req.Password, user.PasswordHash))
                    {
                        //Write this in UserLoginAttempt
                        writer.UpdateUserSuccessfulLoginAttempt(user.UserID);
                        //Set the response Model
                        response.user = reader.MapUserToUserWithoutPassword(user);
                        response.status = 1;
                        response.message = $"Login Successful for Email : {req.UserEmail}";
                    }
                    else
                    {
                        //Write this in UserLoginAttempt
                        writer.UpdateUserFailedLoginAttempt(user.UserID);
                        response.user = null;
                        response.status = 0;
                        response.message = $"Login Unsuccessful. Wrong Password for User Email : {req.UserEmail}";
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error($"Error in Login : {ex}");
            }
            finally
            {
                Log.Info($"Login Method call ended @{DateTime.UtcNow:O}");
                response.responseTime = DateTime.UtcNow;
            }
            return response;
        }
    }
}
