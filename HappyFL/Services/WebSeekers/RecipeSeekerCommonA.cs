using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;
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
                .Select(n => n.InnerText.HtmlDecode().Trim());
        }
 
        protected override IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//{k}", "ul", "ol");

        protected override ScannedIngredientSection ScanIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
        {
            var candidates = subSectionNode.ParentNode.SelectNodes(k => $"/{k}", "h1", "h2", "h3", "h4", "h5")
                .Select(n =>
                {
                    var candidate = new IngredientSection
                    {
                        Name = n.InnerText.HtmlDecode().Trim()
                    };
                    return candidate;
                }).ToList();

            var closestName = subSectionNode.PreviousSibling?.InnerText.HtmlDecode().Trim();
            IngredientSection closestCandidate = candidates.FirstOrDefault(c => c.Name == closestName);
            if (closestCandidate != null)
                candidates = new List<IngredientSection> { closestCandidate };

            var scanned = new ScannedIngredientSection
            {
                Candidates = candidates,
            };

            return scanned;
        }

        protected override List<string> ScanIngredientsFromIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
            => subSectionNode.SelectNodes(k => $"//{k}", "li")
                .Select(n => n
                    .SelectNodes(k => $"//{k}", "text()[parent::li|parent::a[parent::li]|parent::span]")
                    .Select(n2 => n2.InnerText.Trim())
                    .DefaultIfEmpty().Aggregate((a, b) => a + " " + b)
                    .HtmlDecode().Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
    }
}
