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
            return Ok("Login tamamlandı.");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            return Ok("Register tamamlandı.");
        }

        [HttpGet]
        [Route("movie")]
        public IActionResult GetMovie()
        {
            return Ok("Movie tamamlandı.");
        }
        [HttpGet]
        [Route("flower")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetFlower()
        {
            return Ok("Flower tamamlandı.");
        }

    }
}
