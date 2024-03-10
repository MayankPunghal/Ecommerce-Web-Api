using EcomApi.BusinessEntities.RequestProxies;
using EcomApi.Helpers;
using EcomApi.Utils.Common;
using Microsoft.AspNetCore.Mvc;
using EcomApi.BusinessEntities.Processors;
using EcomApi.Utils;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace EcomApi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static readonly string publicKey;
        private static readonly string privateKeyPem;
        static UsersController()
        {
            //using (RSA rsa = RSA.Create())
            //{
            //    // Generate RSA key pair during application startup
            //    publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            //    privateKeyPem = ExportPrivateKeyToPem(rsa);
            //}

            //// Save the public key to .env file
            //SavePublicKeyToEnv(publicKey);

            //// Save both public and private keys to .pem files
            //SaveKeyToPemFile("publicKey.pem", publicKey);
            //SaveKeyToPemFile("privateKey.pem", privateKeyPem);
        }

        [Route(ApiRoute.users.loginbyusername)]
        [HttpPost]
        public IActionResult LoginByUserName([FromBody] LoginByUserNameRequestProxies requestproxy)
        {
            Log.Info($"Login request recieved for UserName : {requestproxy.UserName}");
            var userPro = new UsersProcessor();
            var audience = Request.Headers["Audience"].ToString();
            if (!AppSettings.Settings.Jwt.Audience.Contains(audience) || string.IsNullOrEmpty(audience))
                return Unauthorized();
            var data = userPro.LoginByUserName(requestproxy);
            if (data.status == 0)
                return Unauthorized(data);
            else if (data.status == -1)
                return Unauthorized(data);
            var token = new GeneralController().GenerateJwtToken(data.user.UserName, data.user.RoleName, audience);
            data.token = token;
            return Ok(data);
            //return Ok(data);
        }
        [Route(ApiRoute.users.loginbyemail)]
        [HttpPost]
        public IActionResult LoginByEmail([FromBody] LoginByEmailRequestProxies requestproxy)
        {
            Log.Info($"Login request recieved for User Email : {requestproxy.UserEmail}");
            var userPro = new UsersProcessor();
            var audience = Request.Headers["Audience"].ToString();
            if (!AppSettings.Settings.Jwt.Audience.Contains(audience) || string.IsNullOrEmpty(audience))
                return Unauthorized();
            var data = userPro.LoginByEmail(requestproxy);
            if (data.status == 0)
                return Unauthorized(data);
            else if (data.status == -1)
                return Unauthorized(data);
            var token = new GeneralController().GenerateJwtToken(data.user.UserName, data.user.RoleName, audience);
            return Ok(new { data, token });
            //return Ok(data);
        }
        [Route(ApiRoute.users.getusers)]
        [HttpPost]
        public IActionResult GetUsers([FromBody] GetUserRequestProxy requestproxy)
        {
            Log.Info($"{requestproxy.UserId} requested the list of Users");
            var userPro = new UsersProcessor();
            var data = userPro.GetUsersData(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.users.getuserbyid)]
        [HttpPost]
        public IActionResult GetUserById([FromBody] GetUserByIdRequestProxy requestproxy)
        {
            Log.Info($"{requestproxy.UserId} requested user data for ID : {requestproxy.UserId}");
            var userPro = new UsersProcessor();
            var data = userPro.GetUserDataById(requestproxy);
            return Ok(data);
        }
        [Route(ApiRoute.users.registeruser)]
        [HttpPost]
        public IActionResult RegisterUser([FromBody] SetUserRequestProxy requestproxy)
        {
            Log.Info($"Creating user data for User Name : {requestproxy.UserName}");
            var userPro = new UsersProcessor();
            var data = userPro.RegisterUser(requestproxy);
            return Ok(data);
        }
    }
}
