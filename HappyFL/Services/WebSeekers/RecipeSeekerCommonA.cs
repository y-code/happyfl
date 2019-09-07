using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerCommonA : RecipeSeeker
    {
        public RecipeSeekerCommonA(Uri url, CancellationToken? cancel = null) : base(url, cancel)
        {
        }

        protected override IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc)
        {
            var ingredientsCaptionNodesByNodeName = doc
                .SelectNodes(k => $"//*[text() = '{k}']", "Ingredients", "INGREDIENTS")
                .GroupBy(n => n.Name).ToDictionary(g => g.Key, g => g.ToList());

            if (ingredientsCaptionNodesByNodeName.ContainsKey("h3"))
                return ingredientsCaptionNodesByNodeName["h3"];
            if (ingredientsCaptionNodesByNodeName.ContainsKey("h2"))
                return ingredientsCaptionNodesByNodeName["h2"];
            return new List<HtmlNode>();
        }

        protected override HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
            => ingredientsCaptionNode.ParentNode;

        protected override IEnumerable<string> ScanRecipeNameCandidates(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
        {
            string[] nameNodeNames;
            switch (ingredientsCaptionNode.Name)
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

            return doc.SelectNodes(k => $"//{k}", nameNodeNames)
                .Select(n => n.InnerText.HtmlDecode());
        }
 
        protected override IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//{k}", "ul", "ol");

        protected override WebSeekerService.RecipeSeekResult.IngredientsSection ScanIngredientsSubSection(HtmlDocument doc, HtmlNode subSectionNode)
        {
            var subSection = new WebSeekerService.RecipeSeekResult.IngredientsSection();
            subSection.Ingredients = subSectionNode.SelectNodes(k => $"//{k}", "li")
                .Select(n => n
                    .SelectNodes(k => $"//{k}", "text()[parent::li|parent::a[parent::li]|parent::span]")
                    .Select(n2 => n2.InnerText)
                    .DefaultIfEmpty().Aggregate((a, b) => a + b)
                    .HtmlDecode())
                .ToList();

            subSection.Names = subSectionNode.ParentNode.SelectNodes(k => $"/{k}", "h1", "h2", "h3", "h4", "h5")
                .Select(n => n.InnerText.HtmlDecode()).ToList();

            if (subSection.Names.Contains(subSectionNode.PreviousSibling?.InnerText.HtmlDecode()))
                subSection.Names = new List<string> { subSectionNode.PreviousSibling.InnerText.HtmlDecode() };

            return subSection;
        }
    }
}
