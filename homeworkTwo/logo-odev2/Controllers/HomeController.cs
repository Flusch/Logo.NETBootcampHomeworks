using Microsoft.AspNetCore.Mvc;

namespace logo_odev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpGet]
        [Route("movie")]
        public IActionResult GetMovie()
        {
            return Ok();
        }
        [HttpGet]
        [Route("flower")]
        public IActionResult GetFlower()
        {
            return Ok();
        }

    }
}
