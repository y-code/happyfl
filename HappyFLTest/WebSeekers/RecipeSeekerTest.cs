using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using HappyFL.Services;
using Serilog;
using System.Collections.Generic;
using HappyFL.Models.WebSeeker;
using System;
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
                public List<ScannedRecipe> Recipes { get; set; } = new List<ScannedRecipe>();
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

                Assert.That(actualRecipe.Servings, Is.EqualTo(expectedRecipe.Servings));

                Assert.That(actualRecipe.Dish, Is.Not.Null);
                Assert.That(actualRecipe.Dish.Candidates, Has.Count.EqualTo(expectedRecipe.Dish.Candidates.Count()));
                for (var j = 0; j < expectedRecipe.Dish.Candidates.Count(); j++)
                {
                    var expectedDishCandidate = expectedRecipe.Dish.Candidates.ElementAt(j);
                    var actualDishCandidate = actualRecipe.Dish.Candidates.ElementAt(j);

                    Assert.That(actualDishCandidate.Name, Is.EqualTo(expectedDishCandidate.Name));
                }

                Assert.That(actualRecipe.Ingredients, Has.Count.EqualTo(expectedRecipe.Ingredients.Count()));
                for (var j = 0; j < expectedRecipe.Ingredients.Count(); j++)
                {
                    var expectedIngredient_ = expectedRecipe.Ingredients.ElementAt(i);
                    var actualIngredient_ = actualRecipe.Ingredients.ElementAt(i);

                    Assert.That(actualIngredient_.Candidates, Has.Count.EqualTo(expectedIngredient_.Candidates.Count()));
                    for (var k = 0; k < expectedIngredient_.Candidates.Count(); k++)
                    {
                        var expectedIngredientCandidate = expectedIngredient_.Candidates.ElementAt(k);
                        var actualIngredientCandidate = actualIngredient_.Candidates.ElementAt(k);
                        Assert.That(actualIngredientCandidate.Name, Is.EqualTo(expectedIngredientCandidate.Name));
                        Assert.That(actualIngredientCandidate.Amount, Is.EqualTo(expectedIngredientCandidate.Amount));
                        Assert.That(actualIngredientCandidate.Unit, Is.EqualTo(expectedIngredientCandidate.Unit));
                        Assert.That(actualIngredientCandidate.Note, Is.EqualTo(expectedIngredientCandidate.Note));
                    }

                    var expectedSection = expectedIngredient_.Section;
                    var actualSection = actualIngredient_.Section;

                    Assert.That(actualSection.Id, Is.EqualTo(expectedSection.Id));
                    Assert.That(actualSection.Candidates?.Count(), Is.EqualTo(expectedSection.Candidates.Count()));
                }
            }
        }
    }
}
