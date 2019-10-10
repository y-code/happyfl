using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace HappyFL.Controllers
{
    [Route("[controller]")]
    public class RecipeSeekerLauncherController : Controller
    {
        public RecipeSeekerLauncherController()
        {
        }

        [HttpGet("main.js")]
        public IActionResult GetMainJs()
        {
            ViewData["RecipeSeekerUrl"] = $"https://{this.Request.Host}{this.Request.PathBase}/recipe-seeker/";
            return View();
        }
    }
}
