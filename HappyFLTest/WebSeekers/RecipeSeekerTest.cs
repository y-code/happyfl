using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using HappyFL.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyFL.Test.WebSeekers
{
	[TestFixture(TestOf = typeof(WebSeekerService))]
    [Parallelizable(ParallelScope.Fixtures)]
    public partial class RecipeSeekerTest
    {
		ILogger<WebSeekerService> _logger;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json")
                .Build();
			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
			var factory = new LoggerFactory()
				.AddSerilog();
			_logger = factory.CreateLogger<WebSeekerService>();
		}

        public class TestFindRecipeTestCase
        {
            public class ExpectedResultForTestFindRecipe
            {
                public List<ExpectedIngredientItem> Ingredients { get; } = new List<ExpectedIngredientItem>();
                public int NumberOfResult => Recipes.Count;
                public List<ExpectedRecipe> Recipes { get; set; } = new List<ExpectedRecipe>();
            }

            public class ExpectedRecipe
            {
                public List<ExpectedIngredientSection> Sections { get; } = new List<ExpectedIngredientSection>();
            }

            public class ExpectedIngredientSection
            {
                public List<string> Names { get; } = new List<string>();
                public List<ExpectedIngredientItem> Ingredients { get; } = new List<ExpectedIngredientItem>();
            }

            public class ExpectedIngredientItem
            {
                public List<ExpectedIngredientCandidate> Candidates { get; } = new List<ExpectedIngredientCandidate>();
            }

            public class ExpectedIngredientCandidate
            {
                public string Name { get; set; }
                public float Amount { get; set; }
                public string Unit { get; set; }
                public string Note { get; set; }
            }

            public string Url { get; set; }
            public ExpectedResultForTestFindRecipe Expected { get; set; } = new ExpectedResultForTestFindRecipe();

            public override string ToString() => Url;
        }

        [TestCaseSource(nameof(TestCaseSourceForBBCGoodfood))]
        [TestCaseSource(nameof(TestCaseSourceForAllRecipes))]
        [TestCaseSource(nameof(TestCaseSourceForDelish))]
        [TestCaseSource(nameof(TestCaseSourceForJamieOliver))]
        [TestCaseSource(nameof(TestCaseSourceForCountdown))]
        public void TestFindRecipe(TestFindRecipeTestCase testCase)
        {
            var service = new WebSeekerService(_logger);
            var results = service.FindRecipes(new Uri(testCase.Url));

            Assert.That(results, Has.Count.EqualTo(testCase.Expected.Recipes.Count));
            for (var i = 0; i < testCase.Expected.Recipes.Count; i++)
            {
                var expectedRecipe = testCase.Expected.Recipes[i];
                var actualRecipe = results[i];

                Assert.That(actualRecipe.IngredientsSections, Has.Count.EqualTo(expectedRecipe.Sections.Count));
                for (var j = 0; j < expectedRecipe.Sections.Count; j++)
                {
                    var expectedSection = expectedRecipe.Sections[i];
                    var actualSection = actualRecipe.IngredientsSections[i];

                    Assert.That(actualSection.Names, Has.Count.EqualTo(expectedSection.Names.Count));
                    for (var k = 0; k < expectedSection.Names.Count; k++)
                    {
                        var expectedSectionName = expectedSection.Names[k];
                        var actualSectionName = actualSection.Names[k];
                        Assert.That(actualSectionName, Is.EqualTo(expectedSectionName));
                    }
                    Assert.That(actualSection.Ingredients, Has.Count.EqualTo(expectedSection.Ingredients.Count));
                    for (var k = 0; k < expectedSection.Ingredients.Count; k++)
                    {
                        var expectedIngredient = expectedSection.Ingredients[k];
                        var actualIngredient = actualSection.Ingredients[k];
                        Assert.That(actualIngredient.Candidates, Has.Count.EqualTo(expectedIngredient.Candidates.Count));
                        for (var m = 0; m < expectedIngredient.Candidates.Count; m++)
                        {
                            var expectedCandidate = expectedIngredient.Candidates[m];
                            var actualCandidate = actualIngredient.Candidates[m];
                            Assert.That(actualCandidate.Name, Is.EqualTo(expectedCandidate.Name));
                            Assert.That(actualCandidate.Amount, Is.EqualTo(expectedCandidate.Amount));
                            Assert.That(actualCandidate.Unit, Is.EqualTo(expectedCandidate.Unit));
                            Assert.That(actualCandidate.Note, Is.EqualTo(expectedCandidate.Note));
                        }
                    }
                }
            }
        }

        //[TestCase("https://www.delish.com/cooking/recipe-ideas/a27819262/coconut-chicken-tenders-recipe/")]
        public void GenerateTestCaseCodeOfTestFindRecipe(string url)
        {
            var service = new WebSeekerService(_logger);
            var results = service.FindRecipes(new Uri(url));

            var recipes = results
                .Select(r =>
                {
                    var sections = r.IngredientsSections
                        .Select(s =>
                        {
                            var names = s.Names
                                .Select(n => $@"
                                            ""{n}"",")
                                .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                            var ingredients = s.Ingredients
                                .Select(i =>
                                {
                                    var candidates = i.Candidates
                                        .Select(c => $@"
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {{
                                                        Name = ""{c.Name}"",
                                                        Amount = {c.Amount}f,
                                                        Unit = ""{c.Unit}"",
                                                        Note = ""{c.Note}"",
                                                    }},")
                                        .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                                    return $@"
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {{
                                                Candidates =
                                                {{{candidates}
                                                }}
                                            }},";
                                })
                                .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                            return $@"
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {{
                                        Names =
                                        {{{names}
                                        }},
                                        Ingredients =
                                        {{{ingredients}
                                        }}
                                    }},";
                        })
                        .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");
                    return $@"
                            new TestFindRecipeTestCase.ExpectedRecipe
                            {{
                                Sections =
                                {{{sections}
                                }}
                            }},";
                })
                .DefaultIfEmpty().Aggregate((a, b) => $"{a} {b}");

            var code = $@"
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
            Console.WriteLine(code);
        }
    }
}
