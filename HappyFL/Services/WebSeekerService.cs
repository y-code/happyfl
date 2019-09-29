using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using HappyFL.DB.RecipeManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Threading;
using System.Text;
using HappyFL.Services.WebSeekers;
using HappyFL.Models.WebSeeker;

namespace HappyFL.Services
{
    public class WebSeekerService
    {
        ILogger<WebSeekerService> _logger;

        public WebSeekerService(ILogger<WebSeekerService> logger)
        {
            _logger = logger;
        }

        public List<LinkInfo> FindLinksWithImage(Uri url)
        {
            var result = new List<LinkInfo>();

            var web = new HtmlWeb();
            var html = web.Load(url.AbsoluteUri);
            foreach (var a in html.DocumentNode.SelectNodes("//a[.//img]"))
            {
                var linkUrl = a.Attributes["href"]?.Value;
                if (linkUrl == null)
                    continue;

                if (linkUrl.StartsWith('/'))
                    linkUrl = $"{url.Scheme}://{url.Host}{linkUrl}";

                _logger.LogDebug($"Found a link to {linkUrl}");

                var fileName = linkUrl.Split('/').LastOrDefault();
                fileName = fileName.Split('?').FirstOrDefault();

                var caption = a.InnerText.Trim();
                if (string.IsNullOrEmpty(caption))
                    caption = a.Attributes["title"]?.Value;

                if (caption != null)
                    result.Add(new LinkInfo
                    {
                        Url = new Uri(linkUrl),
                        Caption = caption,
                    });
            }

            return result;
        }

        public List<LinkInfo> FindImages(Uri url)
        {
            var result = new List<LinkInfo>();

            var web = new HtmlWeb();
            var html = web.Load(url.AbsoluteUri);
            var count = 0;
            foreach (var a in html.DocumentNode.SelectNodes("//img"))
            {
                var imageUrl = a.Attributes["src"]?.Value;
                if (imageUrl == null)
                    continue;

                var imageWidth = a.Attributes["width"]?.Value;
                var imageHeight = a.Attributes["height"]?.Value;
                int width, height;
                if ((imageWidth != null && int.TryParse(imageWidth, out width) && width < 200)
                    || (imageHeight != null && int.TryParse(imageHeight, out height) && height < 200))
                    continue;

                _logger.LogDebug($"Found an image loaded from {imageUrl}");

                var fileName = imageUrl.Split('/').LastOrDefault();
                fileName = fileName.Split('?').FirstOrDefault();
                if (string.IsNullOrEmpty(fileName))
                    continue;

                var file = new FileInfo(fileName);
                var extension = file.Extension;

                if (new[] { ".jpg", ".jpeg", ".gif", ".png" }.Contains(extension))
                    result.Add(new LinkInfo
                    {
                        Url = new Uri(imageUrl),
                        Caption = $"{Path.GetFileNameWithoutExtension(file.Name)}-{count++}{extension}",
                    });
            }

            return result;
        }

        public List<LinkInfo> FindImageLinks(Uri url)
        {
            var result = new List<LinkInfo>();

            var web = new HtmlWeb();
            var html = web.Load(url.AbsoluteUri);
            var count = 0;
            foreach (var a in html.DocumentNode.SelectNodes("//a"))
            {
                var linkUrl = a.Attributes["href"]?.Value;
                if (linkUrl == null)
                    continue;

                _logger.LogDebug($"Found a link to {linkUrl}");

                var fileName = linkUrl.Split('/').LastOrDefault();
                fileName = fileName.Split('?').FirstOrDefault();
                if (string.IsNullOrEmpty(fileName))
                    continue;

                var file = new FileInfo(fileName);
                var extension = file.Extension;

                if (new[] { ".jpg", ".jpeg", ".gif", ".png" }.Contains(extension))
                    result.Add(new LinkInfo
                    {
                        Url = new Uri(linkUrl),
                        Caption = $"{Path.GetFileNameWithoutExtension(file.Name)}-{count++}{extension}",
                    });
            }
            return result;
        }

        public List<ScannedRecipe> FindRecipes(Uri url, CancellationToken? cancel = null)
        {
            RecipeSeeker seeker = null;
            switch (url.Host)
            {
                case "www.delish.com":
                    seeker = new RecipeSeekerForDelish(url, cancel);
                    break;
                case "www.bbcgoodfood.com":
                    seeker = new RecipeSeekerForBBCGoodfood(url, cancel);
                    break;
                case "www.allrecipes.com":
                    seeker = new RecipeSeekerForAllRecipes(url, cancel);
                    break;
                default:
                    seeker = new RecipeSeekerCommonA(url, cancel);
                    break;
            }
            return seeker.Scan().ToList();
        }

        public ImageInfo GetImage(Uri url)
        {
            _logger.LogDebug("getting image from {URL}", url);

            var http = new HttpClient();
            var data = http.GetAsync(url.AbsoluteUri).Result;

            using (var stream = data.Content.ReadAsStreamAsync().Result)
            using (var reader = new BinaryReader(stream))
            {
                const int bufferSize = 4096;
                using (var memory = new MemoryStream())
                {
                    byte[] buffer = new byte[bufferSize];
                    int count;
                    while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                        memory.Write(buffer, 0, count);

                    return new ImageInfo
                    {
                        ContentType = data.Content.Headers.ContentType.ToString(),
                        Data = memory.ToArray(),
                    };
                }
            }
        }
    }

    public class LinkInfo
    {
        public Uri Url { get; set; }
        public string Caption { get; set; }
    }

    public class ImageInfo
    {
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }

    public static class WebSeekerServiceExtensions
    {
        public static List<HtmlNode> SelectNodes(this HtmlDocument html, Func<string, string> createXpath, params string[] keyWords)
        {
            return SelectNodes(html.DocumentNode, createXpath, keyWords);
        }

        public static List<HtmlNode> SelectNodes(this HtmlNode node, Func<string, string> createXpath, params string[] keyWords)
        {
            var results = new List<HtmlNode>();
            foreach (var keyWord in keyWords)
            {
                var xPath = node.XPath;
                if (xPath == "/#document")
                    xPath = "";
                var nodes = node.SelectNodes(xPath + createXpath(keyWord))?.ToList();
                if (nodes == null)
                    continue;
                results.AddRange(nodes);
            }
            return results;
        }

        public static string HtmlDecode(this string html)
        {
            return HttpUtility.HtmlDecode(html);
        }
    }
}
