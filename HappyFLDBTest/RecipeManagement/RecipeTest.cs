using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HappyFL.DB.Test.RecipeManagement
{
    [TestFixture(TestOf = typeof(Recipe))]
    public class RecipeTest
    {
        [Test]
        public void TestSerialization0()
        {
            var recipe = new Recipe();
            var json = JsonConvert.SerializeObject(recipe);
            var ds = JsonConvert.DeserializeObject(json);
        }

        [Test]
        public void TestSerialization1()
        {
            var sections = new List<IngredientSection>
            {
                new IngredientSection
                {
                    Name = "Test Section A",
                },
                new IngredientSection
                {
                    Name = "Test Section B",
                },
            };
            var recipe = new Recipe
            {
                Dish = new Dish
                {
                    Name = "Test Dish A"
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Test Ingredient A",
                        Section = sections[0],
                    },
                    new Ingredient
                    {
                        Name = "Test Ingredient B",
                        Section = sections[0],
                    },
                    new Ingredient
                    {
                        Name = "Test Ingredient C",
                        Section = sections[0],
                    },
                    new Ingredient
                    {
                        Name = "Test Ingredient D",
                        Section = sections[1],
                    },
                    new Ingredient
                    {
                        Name = "Test Ingredient E",
                        Section = sections[1],
                    },
                }
            };

            var json = JsonConvert.SerializeObject(recipe);
            var ds = JsonConvert.DeserializeObject(json);
        }
    }
}
