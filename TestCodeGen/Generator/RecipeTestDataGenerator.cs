using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HappyFL.DBFactory;
using Microsoft.EntityFrameworkCore;

namespace TestCodeGen.Generator
{
    public class RecipeTestDataGenerator : TestCodeGenerator
    {
        public override string MenuItemName => "";

        #region Inner Classes

        #endregion

        public RecipeTestDataGenerator()
		{
		}

        public override IEnumerable<TestCode> Generate()
        {
            Environment.SetEnvironmentVariable("DB_ENVIRONMENT", "Development");
            var factory = new HappyFLDbContextFactory();
            var context = factory.CreateDbContext();

            var code = new TestCode();
            code.File = new FileInfo(Path.Combine(OutDir.FullName, $"{TestName}.cs"));
            code.Content = @"
using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.DBFactory;
using HappyFL.DB;

namespace HappyFL.DevDBSetup.RecipeManagement
{
    public class RecipeManagementDataProvider : IDataProvider<HappyFLDbContext>
    {
        protected HappyFLDbContextFactory factory;

        public void CreateData<TFactory>(TFactory factory)
            where TFactory : DbContextFactory<HappyFLDbContext>
        {
            using (var context = factory.CreateDbContext())
            {";

            var recipes = context.Recipes
                .Include(r => r.Dish)
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Section)
                .Select(r => r)
                .ToList();

            var sections = (
                from r in recipes
                from i in r.Ingredients
                select i.Section
            )
                .Distinct()
                .Select((s) => new
                {
                    CodeName = $"section{s.Id}",
                    Section = s,
                })
                .ToDictionary(r => r.Section.Id);

            foreach (var id in sections.Keys)
            {
                var section = sections[id];
                code.Content += $@"
{Indent(4)}var {sections[id].CodeName} = new IngredientSection {{ Name = ""{section.Section.Name}"" }};";
            }

            code.Content += $@"
";

            foreach (var dish in context.Dishes)
            {
                code.Content += $@"
{Indent(4)}context.Add(new Dish
{Indent(4)}{{
{Indent(5)}{nameof(dish.Name)} = ""{dish.Name}"",
{Indent(5)}{nameof(dish.Recipes)} = new List<Recipe>
{Indent(5)}{{{new Func<string>(() => {
                    if (dish.Recipes == null)
                        return "";
                    var str = "";
                    foreach(var recipe in dish.Recipes)
                    {
                        str += $@"
{Indent(6)}new Recipe
{Indent(6)}{{
{Indent(7)}{nameof(recipe.Name)} = ""{recipe.Name}"",
{Indent(7)}{nameof(recipe.UrlOfBase)} = ""{recipe.UrlOfBase}"",
{Indent(7)}{nameof(recipe.Ingredients)} = new List<Ingredient>
{Indent(7)}{{{new Func<string>(() => {
                            var str2 = "";
                            foreach(var ingredient in recipe.Ingredients)
                            {
                                str2 += $@"
{Indent(8)}new Ingredient
{Indent(8)}{{
{Indent(9)}{nameof(ingredient.Name)} = ""{ingredient.Name}"",
{Indent(9)}{nameof(ingredient.Amount)} = {ingredient.Amount}f,
{Indent(9)}{nameof(ingredient.Unit)} = ""{ingredient.Unit}"",
{Indent(9)}{nameof(ingredient.Section)} = {sections[ingredient.Section.Id].CodeName},
{Indent(8)}}},";
                            }
                            return str2;
                        })()}
{Indent(7)}}},
{Indent(6)}}},";
                    }
                    return str;
})()}
{Indent(5)}}},
{Indent(4)}}});";
            }

            code.Content += @"
                context.SaveChanges();
            }
        }
    }
}
";

            yield return code;
        }

        public string Indent(int count)
        {
            return new string(' ', 4 * count);
        }
    }
}
