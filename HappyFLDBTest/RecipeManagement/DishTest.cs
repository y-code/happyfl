using System;
using System.Collections.Generic;
using System.Linq;
using HappyFL.DB.RecipeManagement;
using HappyFL.DBFactory;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HappyFL.DB.Test.RecipeManagement
{
    [TestFixture(TestOf = typeof(Dish))]
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

        [Test]
        public void TestSerialization0()
        {
            var dish = new Dish();
            var json = JsonConvert.SerializeObject(dish);
            var ds = JsonConvert.DeserializeObject(json);
        }

        [Test]
        public void TestSerialization1()
        {
            var dish = new Dish
            {
                Recipes = new List<Recipe>
                {
                    new Recipe
                    {
                        Name = "Recipe A",
                    },
                    new Recipe
                    {
                        Name = "Recipe B",
                    },
                }
            };
            var json = JsonConvert.SerializeObject(dish);

            dynamic ds = JsonConvert.DeserializeObject(json);

            object jRecipes = null;
            RuntimeBinderException exception = null;
            try
            {
                jRecipes = ds.recipes;
            }
            catch (RuntimeBinderException e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Null, "recipes field should not be serialized.");

            Assert.That((string)ds.RecipesSummary[0].Name, Is.EqualTo("Recipe A"));
            Assert.That((string)ds.RecipesSummary[1].Name, Is.EqualTo("Recipe B"));
        }
    }
}
