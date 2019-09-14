using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HappyFL.Models.WebSeeker;
using HtmlAgilityPack;

namespace HappyFL.Services.WebSeekers
{
    public abstract class RecipeSeeker : IRecipeSeeker
    {
        public Uri Url { get; }
        public CancellationToken? Cancel { get; }
        public Encoding Encoding { get; private set; }
        public IIngredientItemParser IngredientItemParser { get; }

        public RecipeSeeker(Uri url, CancellationToken? cancel = null, Encoding encoding = null, IIngredientItemParser ingredientItemParser = null)
        {
            Url = url;
            Cancel = cancel;
            Encoding = encoding;
            IngredientItemParser = ingredientItemParser ?? new IngredientItemParserCommonA();
        }

        public IEnumerable<RecipeSeekResult> Scan()
        {
            var result = new List<RecipeSeekResult>();

            var web = new HtmlWeb();
            if (Encoding != null)
                web.OverrideEncoding = Encoding;

            HtmlDocument doc = null;
            try
            {
                doc = web.Load(Url);
            }
            catch (EncodingNotSupportedException)
            {
                if (Encoding != Encoding.UTF8)
                {
                    Encoding = Encoding.UTF8;
                    return Scan();
                }
            }

            var ingredientsCaptionNodes = ScanIngredientsCaptionNodes(doc);

            foreach (var ingredientsCaptionNode in ingredientsCaptionNodes)
            {
                Cancel?.ThrowIfCancellationRequested();

                var ingredientsSectionNode = ScanIngredientsSectionNode(doc, ingredientsCaptionNode);
                var recipe = new RecipeSeekResult();
                result.Add(recipe);

                recipe.Names = ScanRecipeNameCandidates(doc, ingredientsCaptionNode).ToList();

                var ingredientsSubSectionNodes = ScanIngredientsSubSectionNodes(doc, ingredientsSectionNode);
                foreach (var subSectionNode in ingredientsSubSectionNodes)
                {
                    Cancel?.ThrowIfCancellationRequested();

                    var names = ScanIngredientsSubSectionForNames(doc, subSectionNode);
                    var ingredients = ScanIngredientsSubSectionForIngredients(doc, subSectionNode);

                    recipe.IngredientsSections.Add(new RecipeSeekResult.IngredientsSection
                    {
                        Names = names,
                        Ingredients = ingredients.Select(i => IngredientItemParser.Parse(i)).ToList(),
                    });
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

                foreach (var section in recipe.IngredientsSections.ToList())
                    if (section.Ingredients.Count() == 0)
                        recipe.IngredientsSections.Remove(section);
            }

            return result;
        }

        protected abstract IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc);
        protected abstract HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode);
        protected abstract IEnumerable<string> ScanRecipeNameCandidates(HtmlDocument doc, HtmlNode ingredientsCaptionNode);
        protected abstract IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode);
        protected abstract List<string> ScanIngredientsSubSectionForNames(HtmlDocument doc, HtmlNode subSectionNode);
        protected abstract List<string> ScanIngredientsSubSectionForIngredients(HtmlDocument doc, HtmlNode subSectionNode);
    }
}
