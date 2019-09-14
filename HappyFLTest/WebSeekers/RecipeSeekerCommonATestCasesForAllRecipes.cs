using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        static object[,] TestCaseSourceForAllRecipes =
        {
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.allrecipes.com/recipe/19894/moms-ice-cream-dessert/",
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
                                                        Name = "(20 ounce) package chocolate sandwich cookies",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ") package chocolate sandwich cookies",
                                                        Amount = 20f,
                                                        Unit = "ounce",
                                                        Note = "1 (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1 (",
                                                        Amount = 20f,
                                                        Unit = "ounce",
                                                        Note = ") package chocolate sandwich cookies",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "chocolate sandwich cookies",
                                                        Amount = 1f,
                                                        Unit = "package",
                                                        Note = "1 (20 ounce)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1 (20 ounce)",
                                                        Amount = 1f,
                                                        Unit = "package",
                                                        Note = "chocolate sandwich cookies",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "margarine",
                                                        Amount = 0.5f,
                                                        Unit = "cup",
                                                        Note = "melted",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "chopped Spanish peanuts",
                                                        Amount = 1.5f,
                                                        Unit = "cup",
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
                                                        Name = "vanilla ice cream",
                                                        Amount = 0.5f,
                                                        Unit = "gallon",
                                                        Note = "softened",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "confectioners ' sugar",
                                                        Amount = 2f,
                                                        Unit = "cup",
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
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "(12fluid ounce) can evaporated milk",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = null,
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ") can evaporated milk",
                                                        Amount = 12f,
                                                        Unit = "fl oz",
                                                        Note = "1 (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1 (",
                                                        Amount = 12f,
                                                        Unit = "fl oz",
                                                        Note = ") can evaporated milk",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "semisweet chocolate chips",
                                                        Amount = 0.6666667f,
                                                        Unit = "cup",
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
                                                        Name = "margarine",
                                                        Amount = 0.5f,
                                                        Unit = "cup",
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
                    Url = "https://www.allrecipes.com/recipe/275108/healthier-pan-fried-honey-sesame-chicken/",
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
                                                        Name = "water",
                                                        Amount = 0.5f,
                                                        Unit = "cup",
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
                                                        Name = "low-sodium chicken broth",
                                                        Amount = 1f / 3,
                                                        Unit = "cup",
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
                                                        Name = "ketchup",
                                                        Amount = 0.25f,
                                                        Unit = "cup",
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
                                                        Name = "low-sodium soy sauce",
                                                        Amount = 0.25f,
                                                        Unit = "cup",
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
                                                        Name = "honey",
                                                        Amount = 0.25f,
                                                        Unit = "cup",
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
                                                        Name = "garlic",
                                                        Amount = 2f,
                                                        Unit = "clove",
                                                        Note = "crushed",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "rice vinegar",
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
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "Sriracha sauce",
                                                        Amount = 2f,
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
                                                        Name = "sesame oil",
                                                        Amount = 2f,
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
                                                        Name = "grated fresh ginger root",
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
                                                        Name = "crushed red pepper flakes",
                                                        Amount = 0.25f,
                                                        Unit = "teaspoon",
                                                        Note = "or to taste",
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
                                                        Name = "boneless chicken breast",
                                                        Amount = 4f,
                                                        Unit = null,
                                                        Note = "cut into bite-size pieces",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "water",
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
                                                        Name = "cornstarch",
                                                        Amount = 2f,
                                                        Unit = "tablespoon",
                                                        Note = null,
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
                    Url = "https://www.allrecipes.com/recipe/143082/sweet-sticky-and-spicy-chicken/?internalSource=previously%20viewed&referringContentType=Homepage&clickId=cardslot%202",
                    Expected =
                    {
                        Recipes =
                        {
                            new TestFindRecipeTestCase.ExpectedRecipe
                            {
                                Sections =
                                {
                                }
                            },
                        }
                    },
                },
            },
        };
    }
}
