using Microsoft.AspNetCore.Mvc;
using HappyFL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HappyFL.Services.WebSeekerService;
using System.Threading;
using HappyFL.Models.WebSeeker;
using HappyFL.DB;
using HappyFL.DB.RecipeManagement;
using Microsoft.Extensions.Logging;

namespace HappyFL.Controllers
{
	[Route("api/[controller]")]
	public class WebSeekerController : Controller
	{
        ILogger<WebSeekerController> _logger;

        WebSeekerService _webSeekerService;
        HappyFLDbContext _dbContext;

        public WebSeekerController(
            ILogger<WebSeekerController> logger,
            WebSeekerService webSeekerService,
            HappyFLDbContext dbContext)
		{
            _logger = logger;
			_webSeekerService = webSeekerService;
            _dbContext = dbContext;
		}

		[HttpGet("[action]")]
		public IEnumerable<object> FindLinksWithImage(string url)
		{
			return _webSeekerService.FindLinksWithImage(new Uri(url))
				.Select(l => new
				{
					type = "link",
					url = l.Url.AbsoluteUri,
					caption = l.Caption,
				});
		}

        public class FindImageLinksResponse
        {
            public string type { get; set; } = "image";
            public string url { get; set; }
            public string caption { get; set; }
        }

        [HttpGet("[action]")]
		public IEnumerable<FindImageLinksResponse> FindImageLinks(string url)
		{
			return _webSeekerService.FindImageLinks(new Uri(url))
				.Select(l => new FindImageLinksResponse
                {
					url = l.Url.AbsoluteUri,
					caption = l.Caption,
				})
                .Union(_webSeekerService.FindImages(new Uri(url))
                .Select(i => new FindImageLinksResponse
                {
                    url = i.Url.AbsoluteUri,
                    caption = i.Caption,
                }));
		}

        [HttpGet("[action]")]
        public async Task<IEnumerable<ScannedRecipe>> FindRecipes(string url, CancellationToken cancel)
        {
            return await Task.Run(() => _webSeekerService.FindRecipes(new Uri(url), cancel), cancel);
        }

		[HttpGet("image")]
		public IActionResult GetImage(string url)
		{
			var data = _webSeekerService.GetImage(new Uri(url));
			return File(data.Data, data.ContentType);
		}
	}
}
