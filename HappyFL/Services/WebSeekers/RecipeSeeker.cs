using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public abstract class RecipeSeeker : IRecipeSeeker
    {
        public Uri Url { get; }
        public CancellationToken? Cancel { get; }
        public Encoding Encoding { get; private set; }

        public RecipeSeeker(Uri url, CancellationToken? cancel = null, Encoding encoding = null)
        {
            Url = url;
            Cancel = cancel;
            Encoding = encoding;
        }

        public IEnumerable<WebSeekerService.RecipeSeekResult> Scan()
        {
            var result = new List<WebSeekerService.RecipeSeekResult>();

            var web = new HtmlWeb();
            if (Encoding != null)
                web.OverrideEncoding = Encoding;

            HtmlDocument doc = web.Load(Url);

            var ingredientsCaptionNodes = ScanIngredientsCaptionNodes(doc);

            foreach (var ingredientsCaptionNode in ingredientsCaptionNodes)
            {
                Cancel?.ThrowIfCancellationRequested();

                var ingredientsSectionNode = ScanIngredientsSectionNode(doc, ingredientsCaptionNode);
                var recipe = new WebSeekerService.RecipeSeekResult();
                result.Add(recipe);

                recipe.Names = ScanRecipeNameCandidates(doc, ingredientsCaptionNode).ToList();

                var ingredientsSubSectionNodes = ScanIngredientsSubSectionNodes(doc, ingredientsSectionNode);
                foreach (var subSectionNode in ingredientsSubSectionNodes)
                {
                    Cancel?.ThrowIfCancellationRequested();

                    recipe.IngredientsSections.Add(ScanIngredientsSubSection(doc, subSectionNode));
                }

                // refine data
                var reliableSectionNames = recipe.IngredientsSections.Where(s => s.Names.Count == 1)
                    .SelectMany(s => s.Names).ToList();
                recipe.IngredientsSections.Where(s => s.Names.Count > 1)
                    .ToList().ForEach(s =>
                    {
                        foreach (var i in s.Names.ToList())
                            if (reliableSectionNames.Contains(i))
                                s.Names.Remove(i);
                    });
            }

            return result;
        }

        protected abstract IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc);

        protected abstract HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode);

        protected abstract IEnumerable<string> ScanRecipeNameCandidates(HtmlDocument doc, HtmlNode ingredientsCaptionNode);

        protected abstract IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode);

        protected abstract WebSeekerService.RecipeSeekResult.IngredientsSection ScanIngredientsSubSection(HtmlDocument doc, HtmlNode subSectionNode);
    }
}
