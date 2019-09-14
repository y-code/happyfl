using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        static object[,] TestCaseSourceForDelish =
        {
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.delish.com/cooking/recipe-ideas/a27819262/coconut-chicken-tenders-recipe/",
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
                                            "",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "Cooking spray",
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
                                                        Name = "packed sweetened shredded coconut",
                                                        Amount = 3f,
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
                                                        Name = "extra-virgin olive oil",
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
                                                        Name = "large eggs",
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
                                                        Name = "boneless skinless chicken breasts",
                                                        Amount = 1f,
                                                        Unit = "pound",
                                                        Note = "cut into bite-sized pieces",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "kosher salt",
                                                        Amount = 0.5f,
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
                                                        Name = "all-purpose flour",
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
                                                        Name = "Heinz Simply Ketchup",
                                                        Amount = 1f,
                                                        Unit = null,
                                                        Note = "for serving",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "Heinz Simply Ketchup, for serving",
                                                        Amount = 1f,
                                                        Unit = null,
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
                    Url = "https://www.delish.com/cooking/recipe-ideas/a28930153/cookie-monster-cheesecake-bars-recipe/",
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
                                            "For the crust",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "Cooking spray",
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
                                                        Name = "(1 stick) butter",
                                                        Amount = 0.5f,
                                                        Unit = "cup",
                                                        Note = "softened",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ") butter",
                                                        Amount = 1f,
                                                        Unit = "stick",
                                                        Note = "softened, 1/2 c. (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "1/2 c. (",
                                                        Amount = 1f,
                                                        Unit = "stick",
                                                        Note = ") butter, softened",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "packed brown sugar",
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
                                                        Name = "granulated sugar",
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
                                                        Name = "large egg",
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
                                                        Name = "pure vanilla extract",
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
                                                        Name = "all-purpose flour",
                                                        Amount = 1.25f,
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
                                                        Name = "kosher salt",
                                                        Amount = 0.5f,
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
                                                        Name = "semisweet chocolate chips",
                                                        Amount = 1f,
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
                                            "For the cheesecake",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "(8-oz.) blocks cream cheese",
                                                        Amount = 2f,
                                                        Unit = null,
                                                        Note = "softened",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "oz.) blocks cream cheese",
                                                        Amount = 8f,
                                                        Unit = null,
                                                        Note = "softened, 2 (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "2 (",
                                                        Amount = 8f,
                                                        Unit = null,
                                                        Note = "oz.) blocks cream cheese, softened",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ".) blocks cream cheese",
                                                        Amount = 1f,
                                                        Unit = "ounce",
                                                        Note = "softened, 2 (8-",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "2 (8-",
                                                        Amount = 1f,
                                                        Unit = "ounce",
                                                        Note = ".) blocks cream cheese, softened",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "cream cheese",
                                                        Amount = 1f,
                                                        Unit = "block",
                                                        Note = "softened, 2 (8-oz.)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "2 (8-oz.)",
                                                        Amount = 1f,
                                                        Unit = "block",
                                                        Note = "cream cheese, softened",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "sour cream",
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
                                                        Name = "granulated sugar",
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
                                                        Name = "large eggs",
                                                        Amount = 3f,
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
                                                        Name = "pure vanilla extract",
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
                                                        Name = "kosher salt",
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
                                                        Name = "Blue food coloring",
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
                                                        Name = "mini Chips Ahoy",
                                                        Amount = 1f,
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
                                                        Name = "mini Oreos",
                                                        Amount = 0.5f,
                                                        Unit = "cup",
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
        };
    }
}
