using EcomApi.BusinessEntities.RequestProxies;
using EcomApi.Helpers;
using EcomApi.Utils.Common;
using Microsoft.AspNetCore.Mvc;
using EcomApi.BusinessEntities.Processors;

namespace EcomApi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [Route(ApiRoute.users.loginbyusername)]
        [HttpPost]
        public IActionResult LoginByUserName([FromBody] LoginByUserNameRequestProxies requestproxy)
        {
            Log.Info($"Login request recieved for UserName : {requestproxy.UserName}");
            var userPro = new UsersProcessor();
            var data = userPro.LoginByUserName(requestproxy);
            if (data.status == 0)
                return Ok(data);
            else if (data.status == -1)
                return Ok(data);
            return Ok(data);
        }
        [Route(ApiRoute.users.loginbyemail)]
        [HttpPost]
        public IActionResult LoginByEmail([FromBody] LoginByEmailRequestProxies requestproxy)
        {
            Log.Info($"Login request recieved for User Email : {requestproxy.UserEmail}");
            var userPro = new UsersProcessor();
            var data = userPro.LoginByEmail(requestproxy);
            if (data.status == 0)
                return Unauthorized(data);
            else if(data.status == -1)
                return BadRequest(data);
            return Ok(data);
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
