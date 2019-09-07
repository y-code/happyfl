using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerForDelish : RecipeSeeker
    {
        public RecipeSeekerForDelish(Uri url, CancellationToken? cancel = null) : base(url, cancel)
        {
        }

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
                .Select(n => n.InnerText.HtmlDecode());

        protected override IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//div[contains(@class, '{k}')]", "ingredient-section");

        protected override WebSeekerService.RecipeSeekResult.IngredientsSection ScanIngredientsSubSection(HtmlDocument doc, HtmlNode subSectionNode)
        {
            var subSection = new WebSeekerService.RecipeSeekResult.IngredientsSection();
            subSection.Ingredients = subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-item")
                .Select(n => n.SelectNodes(k =>"//text()", "")
                    .Select(n2 => n2.InnerText)
                    .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}"))
                .ToList();

            subSection.Names = subSectionNode.SelectNodes(k => $"//div[@class = '{k}']", "ingredient-title")
                .Select(n => n.InnerText.HtmlDecode())
                .ToList();

            return subSection;
        }
    }
}
