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
    public class RecipeSeekerCommonA : RecipeSeeker
    {
        private List<Regex> _servingsNumberPatterns = new List<Regex>
        {
            new Regex(@"servings\s*(?'servings'[0-9]+(\.[0-9]+)?)", RegexOptions.IgnoreCase),
            new Regex(@"(?'servings'[0-9]+(\.[0-9]+)?)\s*servings", RegexOptions.IgnoreCase),
            new Regex(@"serves\s*(?'servings'[0-9]+(\.[0-9]+)?)", RegexOptions.IgnoreCase),
            new Regex(@"(?'servings'[0-9]+(\.[0-9]+)?)\s*serves", RegexOptions.IgnoreCase),
            new Regex(@"makes\s*(?'servings'[0-9]+(\.[0-9]+)?)", RegexOptions.IgnoreCase),
            new Regex(@"(?'servings'[0-9]+(\.[0-9]+)?)\s*makes", RegexOptions.IgnoreCase),
        };

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

        protected override IEnumerable<HtmlNode> ScanDishCaptionNodes(HtmlDocument doc, HtmlNode ingredientsCaptionNode)
        {
            string[] nameNodeTags;
            switch (ingredientsCaptionNode.Name)
            {
                case "h3":
                    nameNodeTags = new[] { "h1", "h2" };
                    break;
                case "h2":
                    nameNodeTags = new[] { "h1" };
                    break;
                default:
                    nameNodeTags = new string[0];
                    break;
            }

            List<HtmlNode> nodes = null;
            foreach (var nameNodeTag in nameNodeTags)
            {
                nodes = doc.SelectNodes(k => $"//{k}", nameNodeTag);

                //adjustment
                foreach (var node in nodes.ToList())
                {
                    if (node.SelectNodes(k => $"//{k}", "ancestor::*[contains(@class, 'modal')]").Any())
                        nodes.Remove(node);
                }

                if (nodes != null && nodes.Any())
                    break;
            }
            return nodes;
        }

        protected override ScannedDish ScanDish(HtmlDocument doc, HtmlNode dishCaptionNode)
        {
            var caption = dishCaptionNode.InnerText.HtmlDecode().Trim();

            return new ScannedDish
            {
                Candidates = new List<Dish>
                {
                    new Dish
                    {
                        Name = caption,
                    }
                },
                
            };
        }

        protected override int ScanServings(HtmlDocument doc, HtmlNode dishCaptionNode)
        {

            var candidates = ParseServings(dishCaptionNode.ParentNode);
            return (int)Math.Floor(candidates.Min());
        }

        private IEnumerable<float> ParseServings(HtmlNode targetNode, int expansion = 0)
        {
            IEnumerable<float> servingsList = null;

            var nodes = targetNode.SelectNodes(k => $"//{k}",
                "*[text()[contains(., 'servings')] or text()[contains(., 'SERVINGS')] or text()[contains(., 'Servings')]]",
                "*[text()[contains(., 'serves')] or text()[contains(., 'SERVES')] or text()[contains(., 'Serves')]]",
                "*[text()[contains(., 'makes')] or text()[contains(., 'MAKES')] or text()[contains(., 'Makes')]]"
            );

            if (nodes.Count != 0)
                servingsList = nodes.SelectMany(n => ParseServingsSub(n));

            if (servingsList == null || !servingsList.Any()) {
                if (expansion < 4)
                    servingsList = ParseServings(targetNode.ParentNode, ++expansion);
                else
                    servingsList = new List<float> { 1f };
            }

            return servingsList;
        }

        private IEnumerable<float> ParseServingsSub(HtmlNode targetNode, int expansion =  0)
        {
            IEnumerable<float> servingsList = null;

            foreach (var pattern in _servingsNumberPatterns)
            {
                var matches = pattern.Matches(targetNode.InnerText);

                if (matches.Count() > 0)
                {
                    servingsList = matches
                        .Select(m =>
                        {
                            float r;
                            if (float.TryParse(m.Groups["servings"]?.Value, out r))
                                return (float?)r;
                            return null;
                        })
                        .Where(s => s.HasValue)
                        .Select(s => (float)s);

                    if (servingsList.Any())
                        break;
                }
            }

            if (servingsList == null || !servingsList.Any())
            {
                if (expansion < 3)
                {
                    servingsList = ParseServingsSub(targetNode.ParentNode, ++expansion);
                }
                else
                    return new List<float>();
            }
            return servingsList;
        }

        protected override IEnumerable<HtmlNode> ScanIngredientSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode)
            => ingredientsSectionNode.SelectNodes(k => $"//{k}", "ul", "ol");

        protected override ScannedIngredientSection ScanIngredientSection(HtmlDocument doc, HtmlNode subSectionNode)
        {
            List<IngredientSection> candidates = null;
            foreach (var tag in new string[] { "h1", "h2", "h3", "h4", "h5" })
            {
                candidates = subSectionNode.ParentNode.SelectNodes(k => $"/{k}", tag)
                    .Select(n =>  new IngredientSection
                    {
                        Name = n.InnerText.HtmlDecode().Trim()
                    })
                    .ToList();
                if (candidates != null && candidates.Any())
                    break;
            }

            var closestName = subSectionNode.PreviousSibling?.InnerText.HtmlDecode().Trim();
            IngredientSection closestCandidate = candidates?.FirstOrDefault(c => c.Name == closestName);
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
