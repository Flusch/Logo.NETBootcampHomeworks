using logo_odev4.Business.DTOs;
using logo_odev4.Business.Abstracts;
using logo_odev4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace logo_odev4.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public UserController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = new List<string>
            {
                "John Doe",
                "Samet Kayıkcı",
                "Bill Gates"
            };
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserModel model)
        {
            var token = jwtService.Authenticate(
                new UserDto
                {
                    Name = model.Name,
                    Password = model.Password
                }
                );

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
