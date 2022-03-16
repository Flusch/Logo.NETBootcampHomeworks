using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace logo_odev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public IActionResult Index([FromHeader] Version version)
        {
            Version ver = new Version();
            ver.CompareTo(version);
            return Ok();
        }
        
    }
}
