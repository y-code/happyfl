using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HappyFL.Models.WebSeeker;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerForDelish : RecipeSeeker
    {
        public RecipeSeekerForDelish(Uri url, CancellationToken? cancel = null)
            : base(url, cancel) { }

        protected override IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc)
            => doc.DocumentNode
                .SelectNodes($"//div[@class = 'ingredients-header-title']");

        protected override HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
            => ingredientsCaptionNode
                .SelectNodes(k => $"/ancestor::{k}", "div[@class = 'ingredients']")
                .FirstOrDefault();

        protected override IEnumerable<string> ScanRecipeNameCandidates(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
            => ingredientsCaptionNode
                .SelectNodes(k => $"/ancestor::div[@class = 'site-content']//{k}", "*[contains(@class, 'recipe-hed')]")
                .Select(n => n.InnerText.HtmlDecode().Trim());

        protected override IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//div[contains(@class, '{k}')]", "ingredient-section");

        protected override List<string> ScanIngredientsSubSectionForNames(HtmlDocument doc, HtmlNode subSectionNode)
            => subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-title")
                .Select(n => n.InnerText.HtmlDecode().Trim())
                .ToList();

        protected override List<string> ScanIngredientsSubSectionForIngredients(HtmlDocument doc, HtmlNode subSectionNode)
            => subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-item")
                .Select(n => n.SelectNodes(k =>"//text()", "")
                    .Select(n2 => n2.InnerText.HtmlDecode().Trim())
                    .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}"))
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
    }
}
