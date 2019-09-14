using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public class RecipeSeekerForBBCGoodfood : RecipeSeekerCommonA
    {
        public RecipeSeekerForBBCGoodfood(Uri url, CancellationToken? cancel = null)
            : base(url, cancel) { }

        protected override List<string> ScanIngredientsSubSectionForIngredients(HtmlDocument doc, HtmlNode subSectionNode)
            => subSectionNode.SelectNodes(k => $"//{k}", "li")
                .Select(n => n
                    .SelectNodes(k => $"//{k}", "text()[(parent::li|parent::a[parent::li]|parent::span) and not(ancestor::article[contains(@class, 'glossary')])]")
                    //.Where(n2 => !n2.XPath.Contains("/article"))
                    .Select(n2 => n2.InnerText.Trim())
                    .DefaultIfEmpty().Aggregate((a, b) => a + " " + b)
                    ?.HtmlDecode().Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
    }
}
