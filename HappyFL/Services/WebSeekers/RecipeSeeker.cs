using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HappyFL.DB.RecipeManagement;
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

                var dishCaptionNodes = ScanDishCaptionNodes(doc, ingredientsCaptionNode);

                var dishes = new List<ScannedDish>();
                var servingsList = new List<int>();
                foreach (var dishCaptionNode in dishCaptionNodes)
                {
                    dishes.Add(ScanDish(doc, dishCaptionNode));
                    servingsList.Add(ScanServings(doc, dishCaptionNode));
                }
                recipe.Dish = dishes.FirstOrDefault();
                if (recipe.Dish == null)
                    recipe.Dish = new ScannedDish
                    {
                        Candidates = new List<Dish>(),
                    };
                recipe.Servings = servingsList.Min();

                var ingredientSectionNodes = ScanIngredientSectionNodes(doc, ingredientsSectionNode);
                var ingredients = new List<ScannedIngredient>();
                foreach (var subSectionNode in ingredientSectionNodes)
                {
                    Cancel?.ThrowIfCancellationRequested();

                    var section = ScanIngredientSection(doc, subSectionNode);

                    var ingredientsBySection = ScanIngredientsFromIngredientSection(doc, subSectionNode);

                    ingredients.AddRange(ingredientsBySection.Select(i =>
                    {
                        var d = IngredientItemParser.Parse(i);
                        d.Section = section;
                        return d;
                    }));
                }
                recipe.Ingredients = ingredients;

                // refine data
                var sections = recipe.Ingredients.Select(i => i.Section).Distinct();
                var reliableSectionNames = sections.Where(s => s.Candidates.Count() == 1)
                    .SelectMany(s => s.Candidates.Select(c => c.Name)).ToList();
                foreach (var s in sections.Where(s => s.Candidates.Count() > 1))
                {
                    foreach (var sc in s.Candidates)
                        if (reliableSectionNames.Any(n => n == sc.Name))
                            s.Candidates = s.Candidates.Where(c => c != sc);
                }
            }

            AppendTemporaryIndecies(scanned);

            return scanned;
        }

        private void AppendTemporaryIndecies(List<ScannedRecipe> scanned)
        {
            int sequenceForRecipe = 0;
            int sequenceForDish = 0;
            int sequenceForIngredientSection = 0;
            int sequenceForIngredient = 0;

            foreach (var recipe in scanned)
            {
                recipe.Id = --sequenceForRecipe;
                recipe.Dish.Id = --sequenceForDish;
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
        protected abstract IEnumerable<HtmlNode> ScanDishCaptionNodes(HtmlDocument doc, HtmlNode ingredientsCaptionNode);
        protected abstract ScannedDish ScanDish(HtmlDocument doc, HtmlNode dishCaptionNode);
        protected abstract int ScanServings(HtmlDocument doc, HtmlNode dishCaptionNode);
        protected abstract IEnumerable<HtmlNode> ScanIngredientSectionNodes(HtmlDocument doc, HtmlNode ingredientsSectionNode);
        protected abstract ScannedIngredientSection ScanIngredientSection(HtmlDocument doc, HtmlNode subSectionNode);
        protected abstract List<string> ScanIngredientsFromIngredientSection(HtmlDocument doc, HtmlNode subSectionNode);
    }
}
