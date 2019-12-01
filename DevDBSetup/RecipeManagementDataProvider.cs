using System.Collections.Generic;
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
                var section1 = new IngredientSection { Name = "" };
                var section2 = new IngredientSection { Name = "For the tomato sauce" };
                var section3 = new IngredientSection { Name = "" };
                var section4 = new IngredientSection { Name = "" };
                var section5 = new IngredientSection { Name = "" };

                context.Add(new Dish
                {
                    Name = "Vegan meatballs",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Vegan meatballs from www.bbcgoodfood.com",
                            UrlOfBase = "https://www.bbcgoodfood.com/recipes/vegan-meatballs",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "dried porcini mushrooms",
                                    Amount = 30f,
                                    Unit = "g",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "* 400 g cans chopped tomatoes",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "chilli flakes",
                                    Amount = 1f,
                                    Unit = "pinch",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "large garlic clove",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "onion",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "olive oil",
                                    Amount = 2f,
                                    Unit = "tablespoon",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "spaghetti or soft polenta",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "soft brown sugar",
                                    Amount = 1f,
                                    Unit = "tablespoon",
                                    Section = section2,
                                },
                                new Ingredient
                                {
                                    Name = "fresh breadcrumbs",
                                    Amount = 50f,
                                    Unit = "g",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "rolled oats",
                                    Amount = 50f,
                                    Unit = "g",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "* 400 g can black beans",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "sweet smoked paprika",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "garlic cloves",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "onion",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "olive oil",
                                    Amount = 3f,
                                    Unit = "tablespoon",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "brown rice miso",
                                    Amount = 2f,
                                    Unit = "tablespoon",
                                    Section = section1,
                                },
                                new Ingredient
                                {
                                    Name = "small bunch of basil",
                                    Amount = 0.5f,
                                    Unit = "",
                                    Section = section2,
                                },
                            },
                        },
                        new Recipe
                        {
                            Name = "Best-Ever Vegan Meatballs from www.delish.com",
                            UrlOfBase = "https://www.delish.com/cooking/recipe-ideas/a28708508/vegan-meatballs-recipe/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "Cooking spray",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "canned chickpeas",
                                    Amount = 2f,
                                    Unit = "cup",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "chia seeds",
                                    Amount = 2.5f,
                                    Unit = "tablespoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "water",
                                    Amount = 6f,
                                    Unit = "tablespoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "rolled oats",
                                    Amount = 0.5f,
                                    Unit = "cup",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "tomato paste",
                                    Amount = 1.5f,
                                    Unit = "tablespoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "chopped basil",
                                    Amount = 3f,
                                    Unit = "tablespoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "garlic",
                                    Amount = 1f,
                                    Unit = "clove",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "fennel seeds",
                                    Amount = 0.5f,
                                    Unit = "teaspoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "red pepper flakes",
                                    Amount = 0.25f,
                                    Unit = "teaspoon",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "Kosher salt",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section5,
                                },
                                new Ingredient
                                {
                                    Name = "Freshly ground black pepper",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section5,
                                },
                            },
                        },
                    },
                });
                context.Add(new Dish
                {
                    Name = "Vegetarian Thali",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Harry Hill's vegetarian thali from www.jamieoliver.com",
                            UrlOfBase = "https://www.jamieoliver.com/recipes/vegetable-recipes/harry-hill-s-vegetarian-thali/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "TARKA DAAL",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "CHILLI PANEER",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "onions",
                                    Amount = 3f,
                                    Unit = "spring",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "fresh green chillies",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "piece of ginger",
                                    Amount = 5f,
                                    Unit = "cm",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "of garlic",
                                    Amount = 2f,
                                    Unit = "clove",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "small red pepper",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ghee",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "soy sauce",
                                    Amount = 2f,
                                    Unit = "tablespoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "rice wine vinegar",
                                    Amount = 2f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "hot chilli sauce",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "caster sugar",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "cornflour",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "pack of paneer cheese",
                                    Amount = 226f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "RAITA",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "cucumber",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ripe tomatoes",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "fresh green chillies",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "natural yoghurt",
                                    Amount = 200f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ground cumin",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "PARATHAS",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "strong white bread flour",
                                    Amount = 600f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "fresh coriander",
                                    Amount = 0.5f,
                                    Unit = "bunch",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "chilli powder",
                                    Amount = 0.5f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "garam masala",
                                    Amount = 2f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ground coriander",
                                    Amount = 2f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "yellow split peas",
                                    Amount = 200f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ghee",
                                    Amount = 2f,
                                    Unit = "tablespoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "large onion",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "piece of ginger",
                                    Amount = 2.5f,
                                    Unit = "cm",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "of garlic",
                                    Amount = 2f,
                                    Unit = "clove",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "fresh green chillies",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ripe tomatoes",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "turmeric",
                                    Amount = 0.5f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "chilli powder",
                                    Amount = 0.5f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "lemon",
                                    Amount = 0.5f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "olive oil",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "fresh red chilli",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ALOO GOBI",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "of garlic",
                                    Amount = 2f,
                                    Unit = "clove",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "large onion",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "ghee",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "potatoes",
                                    Amount = 2f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "cumin seeds",
                                    Amount = 2f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "turmeric",
                                    Amount = 0.5f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "cauliflower",
                                    Amount = 200f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "peas",
                                    Amount = 100f,
                                    Unit = "g",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "kasoori methi",
                                    Amount = 1f,
                                    Unit = "teaspoon",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "mustard seeds",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section3,
                                },
                                new Ingredient
                                {
                                    Name = "milk",
                                    Amount = 400f,
                                    Unit = "ml",
                                    Section = section3,
                                },
                            },
                        },
                    },
                });
                context.Add(new Dish
                {
                    Name = "Mexican Refried Beans",
                    Recipes = new List<Recipe>
                    {
                        new Recipe
                        {
                            Name = "Mexican refried beans from www.jamieoliver.com",
                            UrlOfBase = "https://www.jamieoliver.com/recipes/eggs-recipes/mexican-refried-beans/",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient
                                {
                                    Name = "of garlic",
                                    Amount = 2f,
                                    Unit = "clove",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "fresh red chilli",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "of fresh coriander",
                                    Amount = 1f,
                                    Unit = "bunch",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "small jar of roasted peppers",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "olive oil",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "tins of beans",
                                    Amount = 1200f,
                                    Unit = "g",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "large free-range eggs",
                                    Amount = 4f,
                                    Unit = "",
                                    Section = section4,
                                },
                                new Ingredient
                                {
                                    Name = "lime",
                                    Amount = 1f,
                                    Unit = "",
                                    Section = section4,
                                },
                            },
                        },
                    },
                });
                context.SaveChanges();
            }
        }
    }
}

