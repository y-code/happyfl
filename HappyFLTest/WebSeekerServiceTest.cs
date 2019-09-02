using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using HappyFL.Services;
using Serilog;
using System;

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

        [TestCase("https://www.bbcgoodfood.com/recipes/2369635/jerk-chicken-with-rice-and-peas")]
        [TestCase("https://www.countdown.co.nz/recipes/2118/tuna-sushi-style-sandwiches")]
        [TestCase("https://www.allrecipes.com/recipe/19894/moms-ice-cream-dessert/")]
        [TestCase("https://www.jamieoliver.com/recipes/chicken-recipes/chicken-tofu-noodle-soup/")] //TODO:
        [TestCase("https://www.bbcgoodfood.com/recipes/angel-cake-meringue-icing-strawberry-ganache")]
        [TestCase("https://www.delish.com/cooking/recipe-ideas/a27819262/coconut-chicken-tenders-recipe/")] //TODO:
        public void TestFindRecipe(string url)
        {
            var service = new WebSeekerService(_logger);
            var result = service.FindRecipes(new Uri(url));

            Assert.That(result, Has.Count.GreaterThan(0));
            Assert.That(result[0].IngredientsSections, Has.Count.GreaterThan(0));
        }
    }
}
