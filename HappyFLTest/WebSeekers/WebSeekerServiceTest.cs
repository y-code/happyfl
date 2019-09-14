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
    }
}
