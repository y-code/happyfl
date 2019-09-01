using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HappyFL.DB;

namespace HappyFL.Controllers
{
    public class SampleController : Controller
    {
        public SampleController(ILogger<RecipeManagementController> logger, HappyFLDbContext dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
