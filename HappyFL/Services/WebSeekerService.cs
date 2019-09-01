﻿using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using HappyFL.DB.RecipeManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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

        public class RecipeSeekResult
        {
            public List<string> Names { get; set; } = new List<string>();
            public List<IngredientsSection> IngredientsSections { get; set; } = new List<IngredientsSection>();
            public class IngredientsSection
            {
                public List<string> Names { get; set; } = new List<string>();
                public List<string> Ingredients { get; set; } = new List<string>();
            }
        }

        public List<RecipeSeekResult> FindRecipe(Uri url)
        {
            var result = new List<RecipeSeekResult>();

            var web = new HtmlWeb();
            var html = web.Load(url);

            List<HtmlNode> ingredientsSectionLabelNodes = html.SelectNodes(
                k => $"//*[text() = '{k}']", "Ingredients", "INGREDIENTS");
            var ingredientsSectionNodesByNodeName = ingredientsSectionLabelNodes
                .GroupBy(n => n.Name).ToDictionary(g => g.Key, g => g.ToList());

            ingredientsSectionLabelNodes = new List<HtmlNode>();
            if (ingredientsSectionNodesByNodeName.ContainsKey("h3"))
                ingredientsSectionLabelNodes = ingredientsSectionNodesByNodeName["h3"];
            else if (ingredientsSectionNodesByNodeName.ContainsKey("h2"))
                ingredientsSectionLabelNodes = ingredientsSectionNodesByNodeName["h2"];

            foreach (var ingredientsSectionLabelNode in ingredientsSectionLabelNodes)
            {
                var ingredientsSectionNode = ingredientsSectionLabelNode.ParentNode;
                var recipe = new RecipeSeekResult();
                result.Add(recipe);

                // seek Recipe Name Candidates
                string[] nameNodeNames;
                switch (ingredientsSectionLabelNode.Name)
                {
                    case "h3":
                        nameNodeNames = new[] { "h1", "h2" };
                        break;
                    case "h2":
                        nameNodeNames = new[] { "h1" };
                        break;
                    default:
                        nameNodeNames = new string[0];
                        break;
                }

                recipe.Names = html.SelectNodes(k => $"//{k}", nameNodeNames)
                    .Select(n => n.InnerText.HtmlDecode()).ToList();

                // seek Ingredients List
                var listNodes = ingredientsSectionNode.SelectNodes(k => $"//{k}", "ul", "ol");
                foreach (var listNode in listNodes)
                {
                    var section = new RecipeSeekResult.IngredientsSection();
                    recipe.IngredientsSections.Add(section);
                    section.Ingredients = listNode.SelectNodes(k => $"//{k}", "li")
                        .Select(n => n.SelectNodes(k => $"//{k}", "text()[parent::li|parent::a[parent::li]]").Select(n2 => n2.InnerText).DefaultIfEmpty().Aggregate((a, b) => a + b).HtmlDecode()).ToList();
                    
                    section.Names = listNode.ParentNode.SelectNodes(k => $"/{k}", "h1", "h2", "h3", "h4", "h5")
                        .Select(n => n.InnerText.HtmlDecode()).ToList();

                    if (section.Names.Contains(listNode.PreviousSibling?.InnerText.HtmlDecode()))
                        section.Names = new List<string> { listNode.PreviousSibling.InnerText.HtmlDecode() };
                }
                var certainSectionNames = recipe.IngredientsSections.Where(s => s.Names.Count == 1)
                    .SelectMany(s => s.Names).ToList();
                recipe.IngredientsSections.Where(s => s.Names.Count > 1)
                    .ToList().ForEach(s =>
                    {
                        foreach (var i in s.Names.ToList())
                            if (certainSectionNames.Contains(i))
                                s.Names.Remove(i);
                    });
            }

            return result;
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
            return HttpUtility.HtmlDecode(html).Trim();
        }
    }
}