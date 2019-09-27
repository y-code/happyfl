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

        public IEnumerable<ScannedRecipe> Scan()
        {
            var scanned = new List<ScannedRecipe>();

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
                var recipe = new ScannedRecipe();
                scanned.Add(recipe);

                recipe.Names = ScanRecipeNameCandidates(doc, ingredientsCaptionNode).ToList();

                var ingredientsSubSectionNodes = ScanIngredientsSubSectionNodes(doc, ingredientsSectionNode);
                foreach (var subSectionNode in ingredientsSubSectionNodes)
                {
                    Cancel?.ThrowIfCancellationRequested();

                    var section = ScanIngredientSection(doc, subSectionNode);

                    var ingredients = ScanIngredientsFromIngredientSection(doc, subSectionNode);

                    recipe.Ingredients.AddRange(ingredients.Select(i =>
                    {
                        var d = IngredientItemParser.Parse(i);
                        d.Section = section;
                        return d;
                    }));
                }

                // refine data
                var sections = recipe.Ingredients.Select(i => i.Section).Distinct();
                var reliableSectionNames = sections.Where(s => s.Candidates.Count == 1)
                    .SelectMany(s => s.Candidates).ToList();
                sections.Where(s => s.Candidates.Count > 1)
                    .ToList().ForEach(s =>
                    {
                        foreach (var i in s.Candidates.ToList())
                            if (reliableSectionNames.Contains(i))
                                s.Candidates.Remove(i);
                    });
            }

            AppendTemporaryIndecies(scanned);

            return scanned;
        }

        private void AppendTemporaryIndecies(List<ScannedRecipe> scanned)
        {
            int sequenceForRecipe = 0;
            int sequenceForIngredientSection = 0;
            int sequenceForIngredient = 0;

            foreach (var recipe in scanned)
            {
                recipe.Id = --sequenceForRecipe;
                foreach (var s in recipe.Ingredients
                    .Select(i =>
                    {
                        i.Id = --sequenceForIngredient;
                        return i.Section;
                    })
                    .Distinct())
                {
                    s.Id = --sequenceForIngredientSection;
                }
            }


        }

        protected abstract IEnumerable<HtmlNode> ScanIngredientsCaptionNodes(HtmlDocument doc);
        protected abstract HtmlNode ScanIngredientsSectionNode(HtmlDocument doc, HtmlNode ingredientsCaptionNode);
        protected abstract IEnumerable<string> ScanRecipeNameCandidates(HtmlDocument doc, HtmlNode ingredientsCaptionNode);
        protected abstract IEnumerable<HtmlNode> ScanIngredientsSubSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode);
        protected abstract ScannedIngredientSection ScanIngredientSection(HtmlDocument doc, HtmlNode subSectionNode);
        protected abstract List<string> ScanIngredientsFromIngredientSection(HtmlDocument doc, HtmlNode subSectionNode);
    }
}
