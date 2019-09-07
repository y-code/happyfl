using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using HappyFL.Services;
using Serilog;
using System;
using System.Collections.Generic;

namespace HappyFL.Test
{
	[TestFixture(TestOf = typeof(WebSeekerService))]
	public class WebSeekerServiceTest
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

        [TestCase]
        public void TestFindImages()
        {
            var service = new WebSeekerService(_logger);
            var result = service.FindImages(new Uri("https://www.pexels.com/photo/photo-of-vegetable-salad-in-bowls-1640770/"));

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [TestCase]
		public void TestFindLinksWithImage()
		{
			var service = new WebSeekerService(_logger);
			var result = service.FindLinksWithImage(new Uri("https://nz.yahoo.com/"));

			Assert.That(result.Count, Is.GreaterThan(0));
		}

		[TestCase]
		public void TestFindImageLinks()
		{
			var service = new WebSeekerService(_logger);
			var result = service.FindImageLinks(new Uri("http://www.foodeverest.com/downloads/anchovy-salads/"));

			Assert.That(result.Count, Is.GreaterThan(0));
		}

		[TestCase]
		public void TestGetImage()
		{
			var service = new WebSeekerService(_logger);
			var result = service.GetImage(new Uri("https://images.pexels.com/photos/2828283/pexels-photo-2828283.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260"));
		}

        public class ExpectedResultForTestFindRecipe
        {
            public class ExpectedRecipe
            {
                public int NumberOfIngredientsSections { get; set; }
            }
            public int NumberOfResult => Recipes.Count;
            public List<ExpectedRecipe> Recipes { get; set; }
        }

        static object[] TS_TestFindRecipe = {
            new object[]
            {
                "https://www.countdown.co.nz/recipes/2118/tuna-sushi-style-sandwiches",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 1,
                        }
                    }
                },
            },
            new object[]
            {
                "https://www.allrecipes.com/recipe/19894/moms-ice-cream-dessert/",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 1,
                        }
                    }
                },
            },
            new object[]
            {
                "https://www.jamieoliver.com/recipes/chicken-recipes/chicken-tofu-noodle-soup/",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 1,
                        }
                    }
                },
            },
            new object[]
            {
                "https://www.delish.com/cooking/recipe-ideas/a27819262/coconut-chicken-tenders-recipe/",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 1,
                        }
                    }
                },
            },
            new object[]
            {
                "https://www.bbcgoodfood.com/recipes/2369635/jerk-chicken-with-rice-and-peas",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 3,
                        }
                    }
                },
            },
            new object[]
            {
                "https://www.bbcgoodfood.com/recipes/angel-cake-meringue-icing-strawberry-ganache",
                new ExpectedResultForTestFindRecipe
                {
                    Recipes =
                    {
                        new ExpectedResultForTestFindRecipe.ExpectedRecipe
                        {
                            NumberOfIngredientsSections = 5,
                        }
                    }
                },
            },
        };

        [TestCaseSource(nameof(TS_TestFindRecipe))]
        public void TestFindRecipe(string url, ExpectedResultForTestFindRecipe expected)
        {
            var service = new WebSeekerService(_logger);
            var result = service.FindRecipes(new Uri(url));

            Assert.That(result, Has.Count.EqualTo(expected.NumberOfResult));
            for (var i = 0; i < expected.Recipes.Count; i++)
            {
                var expectedRecipe = expected.Recipes[i];
                Assert.That(result[i].IngredientsSections, Has.Count.EqualTo(expectedRecipe.NumberOfIngredientsSections));
            }
        }
    }
}
