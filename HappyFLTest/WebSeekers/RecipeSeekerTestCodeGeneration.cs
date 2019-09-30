using System;
using System.Collections.Generic;
using System.Linq;
using HappyFL.Models.WebSeeker;
using HappyFL.Services;
using NUnit.Framework;

namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        [TestCaseSource(nameof(TestCaseSourceForBBCGoodfood))]
        [TestCaseSource(nameof(TestCaseSourceForAllRecipes))]
        [TestCaseSource(nameof(TestCaseSourceForDelish))]
        [TestCaseSource(nameof(TestCaseSourceForJamieOliver))]
        [TestCaseSource(nameof(TestCaseSourceForCountdown))]
        public void RegenerateTestCaseCode(TestFindRecipeTestCase testCase)
        {
            GenerateTestCaseCodeOfTestFindRecipe(testCase.Url);
        }

        //[TestCase("https://www.allrecipes.com/recipe/143082/sweet-sticky-and-spicy-chicken/?internalSource=previously%20viewed&referringContentType=Homepage&clickId=cardslot%202")]
        public void GenerateTestCaseCodeOfTestFindRecipe(string url)
        {
            var service = new WebSeekerService(_logger);
            var scanned = service.FindRecipes(new Uri(url));

            var code = TestFindRecipeTestCase2ToCode(url, scanned);
            Console.WriteLine(code);
        }

        public string TestFindRecipeTestCase2ToCode(string url, IEnumerable<ScannedRecipe> scanned)
        {
            var recipes = scanned
                .Select(r =>
                {
                    var dishCandidates = r.Dish?.Candidates
                        .Select(d =>
                        {
                            return $@"
                                        new Dish
                                        {{
                                            Name = {d.Name.ToCode()},
                                        }},";
                        })
                        .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");

                    var x = 0;
                    var ingredient = r.Ingredients.ToList();
                    var sections = ingredient
                        .Select(i => i.Section)
                        .Distinct()
                        .ToDictionary(s => s, s =>
                        {
                            var candidates = s.Candidates
                                .Select(c => $@"
                                                new IngredientSection
                                                {{
                                                    Name = {c.Name.ToCode()},
                                                }},")
                                .DefaultIfEmpty()
                                .Aggregate((a, b) => $"{a}{b}");
                            return $@"
                                        Section = new ScannedIngredientSection
                                        {{
                                            Id = {s.Id},
                                            Candidates = new List<IngredientSection>
                                            {{{candidates}
                                            }},
                                        }},";
                        });
                    var ingredients = ingredient
                        .Select(i =>
                        {
                            var candidates = i.Candidates
                                .Select(c => $@"
                                            new Ingredient
                                            {{
                                                Name = {c.Name.ToCode()},
                                                Amount = {c.Amount}f,
                                                Unit = {c.Unit.ToCode()},
                                                Note = {c.Note.ToCode()},
                                            }},")
                                .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                            return $@"
                                    new ScannedIngredient
                                    {{
                                        Candidates = new List<Ingredient>
                                        {{{candidates}
                                        }},{sections[i.Section]}
                                    }},";
                        })
                        .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                    return $@"
                            new ScannedRecipe
                            {{
                                Id = {r.Id},
                                Servings = {r.Servings},
                                Dish = new ScannedDish
                                {{
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {{{dishCandidates}
                                    }},
                                }},
                                Ingredients = new List<ScannedIngredient>
                                {{{ingredients}
                                }}
                            }},";
                })
                .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");

            return $@"
            {{
                new TestFindRecipeTestCase
                {{
                    Url = ""{url}"",
                    Expected =
                    {{
                        Recipes =
                        {{{recipes}
                        }}
                    }},
                }},
            }},
";
        }
    }

    public static class RecipeSeekerTestUtil
    {
        public static string ToCode(this string value)
            => value == null ? "null" : $"\"{value}\"";
    }
}
