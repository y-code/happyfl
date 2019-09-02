using Microsoft.AspNetCore.Mvc;
using HappyFL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HappyFL.Services.WebSeekerService;
using System.Threading;

namespace HappyFL.Controllers
{
	[Route("api/[controller]")]
	public class WebSeekerController : Controller
	{
		WebSeekerService _webSeekerService;

		public WebSeekerController(WebSeekerService webSeekerService)
		{
			_webSeekerService = webSeekerService;
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
        public async Task<IEnumerable<RecipeSeekResult>> FindRecipes(string url, CancellationToken cancel)
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
