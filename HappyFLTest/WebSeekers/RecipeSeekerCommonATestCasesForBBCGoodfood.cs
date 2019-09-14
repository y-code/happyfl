using System;
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
                            new TestFindRecipeTestCase.ExpectedRecipe
                            {
                                Sections =
                                {
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "chicken thighs",
                                                        Amount = 12f,
                                                        Unit = null,
                                                        Note = "bone in",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "12 chicken thighs, bone",
                                                        Amount = 1f,
                                                        Unit = "inch",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "lime",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "halved",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "hot sauce",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "to serve (optional)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "hot sauce, to serve (optional)",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "For the marinade",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "big bunch spring onions",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "roughly chopped",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "onions",
                                                        Amount = 1f,
                                                        Unit = "spring",
                                                        Note = "roughly chopped, 1 big bunch",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1 big bunch",
                                                        Amount = 1f,
                                                        Unit = "spring",
                                                        Note = "onions, roughly chopped",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "thumb-sized piece ginger",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "roughly chopped",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "thumb-sized piece ginger, roughly chopped",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "garlic cloves",
                                                        Amount = 3f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "3 garlic",
                                                        Amount = 1f,
                                                        Unit = "clove",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "small onion",
                                                        Amount = 1.5f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "scotch bonnet chillies",
                                                        Amount = 3f,
                                                        Unit = null,
                                                        Note = "deseeded if you want less heat",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "dried thyme",
                                                        Amount = 0.5f,
                                                        Unit = "teaspoon",
                                                        Note = "or 1 tbsp thyme leaves",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "thyme leaves",
                                                        Amount = 1f,
                                                        Unit = "tablespoon",
                                                        Note = "½tsp dried thyme, or",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "½tsp dried thyme, or",
                                                        Amount = 1f,
                                                        Unit = "tablespoon",
                                                        Note = "thyme leaves",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "lime",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "juiced",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "soy sauce soy",
                                                        Amount = 2f,
                                                        Unit = "tablespoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "vegetable oil",
                                                        Amount = 2f,
                                                        Unit = "tablespoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "brown sugar",
                                                        Amount = 3f,
                                                        Unit = "tablespoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "ground allspice",
                                                        Amount = 1f,
                                                        Unit = "tablespoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "For the rice & peas",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "basmati rice",
                                                        Amount = 200f,
                                                        Unit = "g",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "can coconut milk",
                                                        Amount = 400f,
                                                        Unit = "g",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "bunch spring onions",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "sliced",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "onions",
                                                        Amount = 1f,
                                                        Unit = "spring",
                                                        Note = "sliced, 1 bunch",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1 bunch",
                                                        Amount = 1f,
                                                        Unit = "spring",
                                                        Note = "onions, sliced",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "large thyme sprigs",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "garlic cloves",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = "finely chopped",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "finely chopped",
                                                        Amount = 1f,
                                                        Unit = "clove",
                                                        Note = "2 garlic",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "2 garlic",
                                                        Amount = 1f,
                                                        Unit = "clove",
                                                        Note = "finely chopped",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "ground allspice",
                                                        Amount = 1f,
                                                        Unit = "teaspoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "cans kidney beans",
                                                        Amount = 820f,
                                                        Unit = "g",
                                                        Note = "drained",
                                                    },
                                                }
                                            },
                                        }
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
                            new TestFindRecipeTestCase.ExpectedRecipe
                            {
                                Sections =
                                {
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "egg whites (we used Two Chicks egg whites from a carton)",
                                                        Amount = 480f,
                                                        Unit = "g",
                                                        Note = null,
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "Chicks egg whites from a carton)",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = "480 g egg whites (we used",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "480 g egg whites (we used",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = "Chicks egg whites from a carton)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "carton)",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "480 g egg whites (we used Two Chicks egg whites from",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "480 g egg whites (we used Two Chicks egg whites from",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "carton)",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "white caster sugar",
                                                        Amount = 400f,
                                                        Unit = "g",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "lemon juice",
                                                        Amount = 2f,
                                                        Unit = "tablespoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "vanilla extract",
                                                        Amount = 1f,
                                                        Unit = "teaspoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "plain white flour",
                                                        Amount = 140f,
                                                        Unit = "g",
                                                        Note = "sifted twice",
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "For the meringue icing",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "large egg whites",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "white caster sugar",
                                                        Amount = 225f,
                                                        Unit = "g",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "splash of vanila extract",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "cream of tartar",
                                                        Amount = 1f,
                                                        Unit = "pinch",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "For the strawberry ganache",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "white chocolate",
                                                        Amount = 100f,
                                                        Unit = "g",
                                                        Note = "finely chopped",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "double cream",
                                                        Amount = 50f,
                                                        Unit = "ml",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "strawberries",
                                                        Amount = 50f,
                                                        Unit = "g",
                                                        Note = "chopped",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "red food colouring",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "To decorate",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "strawberries",
                                                        Amount = 250f,
                                                        Unit = "g",
                                                        Note = "quartered or sliced",
                                                    },
                                                }
                                            },
                                        }
                                    },
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                            "Optional decorations",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "white or pink macarons",
                                                        Amount = 3f,
                                                        Unit = null,
                                                        Note = "mini meringues, edible flowers and freeze-dried strawberries",
                                                    },
                                                }
                                            },
                                        }
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
                            new TestFindRecipeTestCase.ExpectedRecipe
                            {
                                Sections =
                                {
                                    new TestFindRecipeTestCase.ExpectedIngredientSection
                                    {
                                        Names =
                                        {
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "self-raising flour",
                                                        Amount = 225f,
                                                        Unit = "g",
                                                        Note = "plus extra for dusting",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "salt",
                                                        Amount = 1f,
                                                        Unit = "pinch",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "cayenne pepper",
                                                        Amount = 1f,
                                                        Unit = "pinch",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "baking powder",
                                                        Amount = 1f,
                                                        Unit = "teaspoon",
                                                        Note = null,
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "chilled butter",
                                                        Amount = 55f,
                                                        Unit = "g",
                                                        Note = "cut into cubes",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "mature cheddar",
                                                        Amount = 120f,
                                                        Unit = "g",
                                                        Note = "grated",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "milk",
                                                        Amount = 100f,
                                                        Unit = "ml",
                                                        Note = "plus 1 tbsp for glazing",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "for glazing",
                                                        Amount = 1f,
                                                        Unit = "tablespoon",
                                                        Note = "90 - 100 ml milk, plus",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "90 - 100 ml milk, plus",
                                                        Amount = 1f,
                                                        Unit = "tablespoon",
                                                        Note = "for glazing",
                                                    },
                                                }
                                            },
                                        }
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
