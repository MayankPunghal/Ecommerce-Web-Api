using EcomApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EcomApi.Controllers
{
    public class GeneralController : Controller
    {
        [HttpGet]
        [Route(ApiRoute.general.checkhealth)]
        public IActionResult CheckHealth()
        {
            return Ok(new { Status = "ok" });
        }
    }
}
