using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerForAllRecipes : RecipeSeekerCommonA
    {
        public RecipeSeekerForAllRecipes(Uri url, CancellationToken? cancel = null)
            : base(url, cancel) { }

        protected override HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
        {
            HtmlNode sectionNode = null;
            var sectionTag = ingredientsCaptionNode.SelectNodes(k => $"/{k}", "ancestor::section");
            if (sectionTag.Any())
                sectionNode = sectionTag.OrderByDescending(t => t.XPath.Length).First();

            if (sectionNode == null)
                sectionNode = ingredientsCaptionNode.ParentNode;
            return sectionNode;
        }

        protected override List<string> ScanIngredientsFromIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
            => base.ScanIngredientsFromIngredientSection(doc, subSectionNode)
                .Where(i =>
                {
                    switch (i)
                    {
                        case "Adjust":
                        case "US":
                        case "Metric":
                        case "Sauce:":
                        case "Add all ingredients to list":
                            return false;
                        default:
                            return true;
                    }
                })
                .ToList();
    }
}
