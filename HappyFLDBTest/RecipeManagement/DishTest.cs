using System;
using System.Collections.Generic;
using System.Linq;
using HappyFL.DB.RecipeManagement;
using HappyFL.DBFactory;
using NUnit.Framework;

namespace HappyFL.DB.Test.RecipeManagement
{
    [TestFixture]
    public class DishTest
    {
        protected HappyFLDbContextFactory Factory { get; private set; }

        public DishTest()
        {
            Factory = new HappyFLDbContextFactory();
        }

        [Test]
        public void TestRetrieveDishes()
        {
            List<Dish> dishes = null;
            using (var context = Factory.CreateDbContext())
            {
                dishes = context.Dishes.ToList();
            }

            Assert.That(dishes, Has.Count.EqualTo(3));
        }
    }
}
