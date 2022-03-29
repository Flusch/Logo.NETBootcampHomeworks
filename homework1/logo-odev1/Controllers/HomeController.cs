using logo_odev1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace logo_odev1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult Form(DataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }*/

        [HttpPost]
        public IActionResult Form(DataViewModel model)
        {
            var GoodLogin = new ResponseViewModel
            {
                Success = true,
                Error = "Null",
                Data = "Giriş işlemi başarılı"

            };
            var BadLogin = new ResponseViewModel
            {
                Success = false,
                Error = "Hatalı giriş",
                Data = "Null"

            };
            if (!ModelState.IsValid)
            {
                ViewData["success"] = "Success :" + BadLogin.Success;
                ViewData["data"] = " Data: " + BadLogin.Data;
                ViewData["error"] = " Error: " + BadLogin.Error;
                return View();
            }
            ViewData["success"] = "Success :" + GoodLogin.Success;
            ViewData["data"] = " Data: " + GoodLogin.Data;
            ViewData["error"] = " Error: " + GoodLogin.Error;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
