using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        static object[,] TestCaseSourceForBBCGoodfood =
        {
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.bbcgoodfood.com/recipes/2369635/jerk-chicken-with-rice-and-peas",
                    Expected =
                    {
                        Recipes =
                        {
                            new ScannedRecipe
                            {
                                Id = -1,
                                Dish = new ScannedDish
                                {
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {
                                    }
                                },
                                Ingredients = new List<ScannedIngredient>
                                {
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "chicken thighs",
                                                Amount = 12f,
                                                Unit = null,
                                                Note = "bone in",
                                            },
                                            new Ingredient
                                            {
                                                Name = "12 chicken thighs, bone",
                                                Amount = 1f,
                                                Unit = "inch",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "lime",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "halved",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "hot sauce",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "to serve (optional)",
                                            },
                                            new Ingredient
                                            {
                                                Name = "hot sauce, to serve (optional)",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "big bunch spring onions",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "roughly chopped",
                                            },
                                            new Ingredient
                                            {
                                                Name = "onions",
                                                Amount = 1f,
                                                Unit = "spring",
                                                Note = "roughly chopped, 1 big bunch",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1 big bunch",
                                                Amount = 1f,
                                                Unit = "spring",
                                                Note = "onions, roughly chopped",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "thumb-sized piece ginger",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "roughly chopped",
                                            },
                                            new Ingredient
                                            {
                                                Name = "thumb-sized piece ginger, roughly chopped",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "garlic cloves",
                                                Amount = 3f,
                                                Unit = null,
                                                Note = null,
                                            },
                                            new Ingredient
                                            {
                                                Name = "3 garlic",
                                                Amount = 1f,
                                                Unit = "clove",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "small onion",
                                                Amount = 1.5f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "scotch bonnet chillies",
                                                Amount = 3f,
                                                Unit = null,
                                                Note = "deseeded if you want less heat",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "dried thyme",
                                                Amount = 0.5f,
                                                Unit = "teaspoon",
                                                Note = "or 1 tbsp thyme leaves",
                                            },
                                            new Ingredient
                                            {
                                                Name = "thyme leaves",
                                                Amount = 1f,
                                                Unit = "tablespoon",
                                                Note = "½tsp dried thyme, or",
                                            },
                                            new Ingredient
                                            {
                                                Name = "½tsp dried thyme, or",
                                                Amount = 1f,
                                                Unit = "tablespoon",
                                                Note = "thyme leaves",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "lime",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "juiced",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "soy sauce soy",
                                                Amount = 2f,
                                                Unit = "tablespoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "vegetable oil",
                                                Amount = 2f,
                                                Unit = "tablespoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "brown sugar",
                                                Amount = 3f,
                                                Unit = "tablespoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "ground allspice",
                                                Amount = 1f,
                                                Unit = "tablespoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the marinade",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "basmati rice",
                                                Amount = 200f,
                                                Unit = "g",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "can coconut milk",
                                                Amount = 400f,
                                                Unit = "g",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "bunch spring onions",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "sliced",
                                            },
                                            new Ingredient
                                            {
                                                Name = "onions",
                                                Amount = 1f,
                                                Unit = "spring",
                                                Note = "sliced, 1 bunch",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1 bunch",
                                                Amount = 1f,
                                                Unit = "spring",
                                                Note = "onions, sliced",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "large thyme sprigs",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "garlic cloves",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = "finely chopped",
                                            },
                                            new Ingredient
                                            {
                                                Name = "finely chopped",
                                                Amount = 1f,
                                                Unit = "clove",
                                                Note = "2 garlic",
                                            },
                                            new Ingredient
                                            {
                                                Name = "2 garlic",
                                                Amount = 1f,
                                                Unit = "clove",
                                                Note = "finely chopped",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "ground allspice",
                                                Amount = 1f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "cans kidney beans",
                                                Amount = 820f,
                                                Unit = "g",
                                                Note = "drained",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the rice & peas",
                                                },
                                            },
                                        },
                                    },
                                }
                            },
                        }
                    },
                },
            },
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.bbcgoodfood.com/recipes/angel-cake-meringue-icing-strawberry-ganache",
                    Expected =
                    {
                        Recipes =
                        {
                            new ScannedRecipe
                            {
                                Id = -1,
                                Dish = new ScannedDish
                                {
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {
                                    }
                                },
                                Ingredients = new List<ScannedIngredient>
                                {
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "egg whites (we used Two Chicks egg whites from a carton)",
                                                Amount = 480f,
                                                Unit = "g",
                                                Note = null,
                                            },
                                            new Ingredient
                                            {
                                                Name = "Chicks egg whites from a carton)",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = "480 g egg whites (we used",
                                            },
                                            new Ingredient
                                            {
                                                Name = "480 g egg whites (we used",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = "Chicks egg whites from a carton)",
                                            },
                                            new Ingredient
                                            {
                                                Name = "carton)",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "480 g egg whites (we used Two Chicks egg whites from",
                                            },
                                            new Ingredient
                                            {
                                                Name = "480 g egg whites (we used Two Chicks egg whites from",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "carton)",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "white caster sugar",
                                                Amount = 400f,
                                                Unit = "g",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "lemon juice",
                                                Amount = 2f,
                                                Unit = "tablespoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "vanilla extract",
                                                Amount = 1f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "plain white flour",
                                                Amount = 140f,
                                                Unit = "g",
                                                Note = "sifted twice",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "large egg whites",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the meringue icing",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "white caster sugar",
                                                Amount = 225f,
                                                Unit = "g",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the meringue icing",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "splash of vanila extract",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the meringue icing",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "cream of tartar",
                                                Amount = 1f,
                                                Unit = "pinch",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the meringue icing",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "white chocolate",
                                                Amount = 100f,
                                                Unit = "g",
                                                Note = "finely chopped",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the strawberry ganache",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "double cream",
                                                Amount = 50f,
                                                Unit = "ml",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the strawberry ganache",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "strawberries",
                                                Amount = 50f,
                                                Unit = "g",
                                                Note = "chopped",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the strawberry ganache",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "red food colouring",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -3,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the strawberry ganache",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "strawberries",
                                                Amount = 250f,
                                                Unit = "g",
                                                Note = "quartered or sliced",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -4,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "To decorate",
                                                },
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "white or pink macarons",
                                                Amount = 3f,
                                                Unit = null,
                                                Note = "mini meringues, edible flowers and freeze-dried strawberries",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -5,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "Optional decorations",
                                                },
                                            },
                                        },
                                    },
                                }
                            },
                        }
                    },
                },
            },
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.bbcgoodfood.com/recipes/classic-cheese-scones",
                    Expected =
                    {
                        Recipes =
                        {
                            new ScannedRecipe
                            {
                                Id = -1,
                                Dish = new ScannedDish
                                {
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {
                                    }
                                },
                                Ingredients = new List<ScannedIngredient>
                                {
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "self-raising flour",
                                                Amount = 225f,
                                                Unit = "g",
                                                Note = "plus extra for dusting",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "salt",
                                                Amount = 1f,
                                                Unit = "pinch",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "cayenne pepper",
                                                Amount = 1f,
                                                Unit = "pinch",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "baking powder",
                                                Amount = 1f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "chilled butter",
                                                Amount = 55f,
                                                Unit = "g",
                                                Note = "cut into cubes",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "mature cheddar",
                                                Amount = 120f,
                                                Unit = "g",
                                                Note = "grated",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "milk",
                                                Amount = 100f,
                                                Unit = "ml",
                                                Note = "plus 1 tbsp for glazing",
                                            },
                                            new Ingredient
                                            {
                                                Name = "for glazing",
                                                Amount = 1f,
                                                Unit = "tablespoon",
                                                Note = "90 - 100 ml milk, plus",
                                            },
                                            new Ingredient
                                            {
                                                Name = "90 - 100 ml milk, plus",
                                                Amount = 1f,
                                                Unit = "tablespoon",
                                                Note = "for glazing",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                            },
                                        },
                                    },
                                }
                            },
                        }
                    },
                },
            },
        };
    }
}
