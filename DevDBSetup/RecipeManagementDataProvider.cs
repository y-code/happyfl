using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            {
                var section001 = new IngredientSection { Name = "Marinade" };
                var section002 = new IngredientSection { Name = "Braising" };
                var section011 = new IngredientSection { Name = "Water starch" };
                var section012 = new IngredientSection { Name = "Serving" };
                context.Add(new Dish
                {
                    Name = "Mapo Tofu",
                    Cuisine = "Chinese",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Mapo Tofu - Recipe 1",
                            UrlOfBase = "https://omnivorescookbook.com/authentic-mapo-tofu/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "Pork Mince",
                                    Amount = 120f,
                                    Unit = "g",
                                    Section = section001,
                                },
                                new Ingredient
                                {
                                    Name = "Shaoxing wine",
                                    Amount = 2f,
                                    Unit = "tsp",
                                    Note = "or dry sherry",
                                    Section = section001,
                                },
                                new Ingredient
                                {
                                    Name = "light soy sauce",
                                    Amount = 1f,
                                    Unit = "tsp",
                                    Section = section001,
                                },
                                new Ingredient
                                {
                                    Name = "Minced Ginger",
                                    Amount = 0.5f,
                                    Unit = "tsp",
                                    Note = "or 1/4 teaspoon ginger powder",
                                    Section = section001,
                                },
                                new Ingredient
                                {
                                    Name = "Cornstarch",
                                    Amount = 1f,
                                    Unit = "tsp",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Sichuan Peppercorns",
                                    Amount = 2f,
                                    Unit = "tsp",
                                    Note = "increase to 3 teaspoons if you like your dish extra numbing",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Vegetable Oil",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Doubanjiang",
                                    Amount = 3f,
                                    Unit = "tbsp",
                                    Note = "spicy fermented bean paste",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Green Onion",
                                    Amount = 2f,
                                    Unit = "tbsp",
                                    Note = "chopped",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Firm or Medium Firm Tofu",
                                    Amount = 400f,
                                    Unit = "g",
                                    Note = "cut into 1.5cm (1/2 inch) squares",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Water",
                                    Amount = 1f,
                                    Unit = "cup",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Chili Oil",
                                    Amount = 2f,
                                    Unit = "tsp",
                                    Note = "1 teaspoon for a less spicy dish",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Five-Spice Powder",
                                    Amount = 0.25f,
                                    Unit = "tsp",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Sugar",
                                    Amount = 1f,
                                    Unit = "tsp",
                                    Note = "or to taste",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Green Part of Chopped Green Onion",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Note = "for garnish (optional)",
                                    Section = section002,
                                },
                                new Ingredient
                                {
                                    Name = "Steamed Rice",
                                    Note = "to serve with (optional)",
                                    Section = section002,
                                },
                            },
                        },
                        new Recipe
                        {
                            Name = "Mapo Tofu - Recipe 2",
                            UrlOfBase = "https://www.chinasichuanfood.com/mapo-tofu-recipe/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "Silken Tofu",
                                    Amount = 450f,
                                    Unit = "g",
                                    Note = "I am using Szechuan tender lushui tofu",
                                },
                                new Ingredient
                                {
                                    Name = "Minced Meat-Beef or Pork",
                                    Amount = 100f,
                                    Unit = "g",
                                },
                                new Ingredient
                                {
                                    Name = "Sesame Oil",
                                    Amount = 0.5f,
                                    Unit = "tbsp",
                                },
                                new Ingredient
                                {
                                    Name = "Doubanjiang",
                                    Amount = 1.5f,
                                    Unit = "tbsp",
                                    Note = "roughly chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Fermented Black Beans",
                                    Amount = 0.5f,
                                    Unit = "tbsp",
                                    Note = "also known as dou-chi and fermented soya beans, roughly chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Pepper Flakes or Powder",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Note = "optional",
                                },
                                new Ingredient
                                {
                                    Name = "Salt",
                                    Amount = 0.5f,
                                    Unit = "tsp",
                                },
                                new Ingredient
                                {
                                    Name = "Sichuan Pepper",
                                    Amount = 0.5f,
                                    Unit = "tbsp",
                                    Note = "for making fresh ground powder",
                                },
                                new Ingredient
                                {
                                    Name = "Light Soy Sauce",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                },
                                new Ingredient
                                {
                                    Name = "Water or Broth",
                                    Amount = 400f,
                                    Unit = "ml",
                                    Note = "for braising, I use 400ml this time",
                                },
                                new Ingredient
                                {
                                    Name = "Cooking Oil",
                                    Amount = 2f,
                                    Unit = "tbsp",
                                },
                                new Ingredient
                                {
                                    Name = "Scallion Whites",
                                    Amount = 2f,
                                    Unit = "",
                                    Note = "finely chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Garlic Greens or Scallion Greens",
                                    Amount = 4f,
                                    Unit = "",
                                    Note = "finely chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Garlic Cloves",
                                    Amount = 2f,
                                    Unit = "",
                                    Note = "finely chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Ginger Slices",
                                    Amount = 5f,
                                    Unit = "",
                                    Note = "finely minced (around 1 teaspoon)",
                                },
                                new Ingredient
                                {
                                    Name = "Sugar",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Note = "optional for reducing the spiciness",
                                },
                                new Ingredient
                                {
                                    Name = "Water",
                                    Amount = 2.5f,
                                    Unit = "tbsp",
                                    Section = section011,
                                },
                                new Ingredient
                                {
                                    Name = "Cornstarch",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Section = section011,
                                },
                                new Ingredient
                                {
                                    Name = "Steamed Rice",
                                    Note = "for serving",
                                    Section = section012,
                                },
                            },
                        },
                        new Recipe
                        {
                            Name = "Mapo Tofu - Recipe 3",
                            UrlOfBase = "https://thewoksoflife.com/ma-po-tofu-real-deal/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "Oil",
                                    Amount = 0.5f,
                                    Unit = "cup",
                                    Note = "divided",
                                },
                                new Ingredient
                                {
                                    Name = "fresh Thai bird chili peppers",
                                    Amount = 1f,
                                    Unit = "",
                                    Note = "thinly sliced",
                                },
                                new Ingredient
                                {
                                    Name = "dried red chilies",
                                    Amount = 6f,
                                    Unit = "",
                                    Note = "roughly chopped",
                                },
                                new Ingredient
                                {
                                    Name = "Sichuan peppercorns",
                                    Amount = 1.5f,
                                    Unit = "tbsp",
                                    Note = "coarsely ground, plus 1/4 teaspoon for garnish at the end",
                                },
                                new Ingredient
                                {
                                    Name = "Ginger",
                                    Amount = 3f,
                                    Unit = "tbsp",
                                    Note = "finely minced",
                                },
                                new Ingredient
                                {
                                    Name = "Garlic",
                                    Amount = 3f,
                                    Unit = "tbsp",
                                    Note = "finely minced",
                                },
                                new Ingredient
                                {
                                    Name = "ground pork",
                                    Amount = 8f,
                                    Unit = "oz",
                                    Note = "225g",
                                },
                                new Ingredient
                                {
                                    Name = "spicy bean sauce",
                                    Amount = 1f,
                                    Unit = "tbsp",
                                    Note = "depending on your desired salt/spice levels",
                                },
                                new Ingredient
                                {
                                    Name = "low sodium chicken broth",
                                    Amount = 0.666f,
                                    Unit = "cup",
                                    Note = "or water",
                                },
                                new Ingredient
                                {
                                    Name = "silken tofu",
                                    Amount = 1f,
                                    Unit = "lb",
                                    Note = "450g, cut into 1 inch cubes",
                                },
                                new Ingredient
                                {
                                    Name = "cornstarch",
                                    Amount = 1.5f,
                                    Unit = "tsp",
                                },
                                new Ingredient
                                {
                                    Name = "sesame oil",
                                    Amount = 0.25f,
                                    Unit = "tsp",
                                    Note = "optional",
                                },
                                new Ingredient
                                {
                                    Name = "Sugar",
                                    Amount = 0.25f,
                                    Unit = "tsp",
                                    Note = "optional",
                                },
                                new Ingredient
                                {
                                    Name = "scallion",
                                    Amount = 1f,
                                    Unit = "",
                                    Note = "finely chopped",
                                },
                            },
                        },
                    },
                });
                context.Add(new Dish
                {
                    Name = "Risotto",
                    Cuisine = "Italian",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Risotto - Recipe 1",
                        },
                    },
                });
                context.Add(new Dish
                {
                    Name = "Carbonara",
                    Cuisine = "Italian",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Carbonara - Recipe 1",
                        },
                        new Recipe
                        {
                            Name = "Carbonara - Recipe 2",
                        },
                    },
                });
                context.SaveChanges();
            }
        }
    }
}
