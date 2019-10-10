using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerForDelish : RecipeSeeker
    {
        private Regex _servingsNumberPattern = new Regex(@"[0-9]+(\.[0-9]+)?", RegexOptions.IgnoreCase);

        public RecipeSeekerForDelish(Uri url, CancellationToken? cancel = null)
            : base(url, cancel) { }

        protected override IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc)
            => doc.DocumentNode
                .SelectNodes($"//div[@class = 'ingredients-header-title']");

        protected override HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
            => ingredientsCaptionNode
                .SelectNodes(k => $"/ancestor::{k}", "div[@class = 'ingredients']")
                .FirstOrDefault();

        protected override IEnumerable<HtmlNode> ScanDishCaptionNodes(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
            => ingredientsCaptionNode
                .SelectNodes(k => $"/ancestor::div[@class = 'site-content']//{k}", "*[contains(@class, 'recipe-hed')]");

        protected override ScannedDish ScanDish(HtmlDocument doc, HtmlNode dishCaptionNode)
            => new ScannedDish
            {
                Candidates = new List<Dish>
                {
                    new Dish
                    {
                        Name = dishCaptionNode.InnerText.HtmlDecode().Trim()
                    }
                }
            };

        protected override int ScanServings(HtmlDocument doc, HtmlNode dishCaptionNode)
        {
            return (int)Math.Floor(dishCaptionNode
                .SelectNodes(k => $"/ancestor::div[@class = 'site-content']//{k}", "*[@class = 'yields-amount']")
                .SelectMany(n =>
                {
                    var matches = _servingsNumberPattern.Matches(n.InnerText);
                    return matches
                        .Select(m =>
                        {
                            float r;
                            if (float.TryParse(m.Value, out r))
                                return (float?)r;
                            return null;
                        })
                        .Where(s => s.HasValue)
                        .Select(s => (float)s);
                })
                .DefaultIfEmpty(0f)
                .Min());
        }

        protected override IEnumerable<HtmlNode> ScanIngredientSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//div[contains(@class, '{k}')]", "ingredient-section");

        protected override ScannedIngredientSection ScanIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
            => new ScannedIngredientSection
            {
                Candidates = subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-title")
                .Select(n => new IngredientSection { Name = n.InnerText.HtmlDecode().Trim() })
                .ToList()
            };

        protected override List<string> ScanIngredientsFromIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
            => subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-item")
                .Select(n => n.SelectNodes(k =>"//text()", "")
                    .Select(n2 => n2.InnerText.HtmlDecode().Trim())
                    .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}"))
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
    }
}
