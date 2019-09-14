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

        protected override List<string> ScanIngredientsSubSectionForIngredients(HtmlDocument doc, HtmlNode subSectionNode)
            => base.ScanIngredientsSubSectionForIngredients(doc, subSectionNode)
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
