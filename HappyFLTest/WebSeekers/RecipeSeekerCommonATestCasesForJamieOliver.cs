using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        static object[,] TestCaseSourceForJamieOliver =
        {
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.jamieoliver.com/recipes/chicken-recipes/chicken-tofu-noodle-soup/",
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
                                                        Name = "shallots",
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
                                                        Name = "of garlic",
                                                        Amount = 2f,
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
                                                        Name = "piece of ginger",
                                                        Amount = 2f,
                                                        Unit = "cm",
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
                                                        Name = "free-range chicken thighs",
                                                        Amount = 4f,
                                                        Unit = null,
                                                        Note = "skin off, bone in",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "4 free-range chicken thighs, skin off, bone",
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
                                                        Name = "groundnut oil",
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
                                                        Name = "sesame oil",
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
                                                        Name = "star anise",
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
                                                        Name = "low-salt soy sauce",
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
                                                        Name = "fine rice noodles",
                                                        Amount = 100f,
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
                                                        Name = "fresh coriander",
                                                        Amount = 0.5f,
                                                        Unit = "bunch",
                                                        Note = "(15 g)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ")",
                                                        Amount = 15f,
                                                        Unit = "g",
                                                        Note = "½ a bunch of fresh coriander, (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "½ a bunch of fresh coriander, (",
                                                        Amount = 15f,
                                                        Unit = "g",
                                                        Note = ")",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "fresh mint",
                                                        Amount = 0.5f,
                                                        Unit = "bunch",
                                                        Note = "(15 g)",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = ")",
                                                        Amount = 15f,
                                                        Unit = "g",
                                                        Note = "½ a bunch of fresh mint, (",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "½ a bunch of fresh mint, (",
                                                        Amount = 15f,
                                                        Unit = "g",
                                                        Note = ")",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "tofu",
                                                        Amount = 100f,
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
                                                        Name = "onions",
                                                        Amount = 4f,
                                                        Unit = "spring",
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
                                                        Name = "fresh red chilli",
                                                        Amount = 0.5f,
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
                                                        Name = "baby spinach",
                                                        Amount = 100f,
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
                                                        Name = "seaweed nori sheets",
                                                        Amount = 4f,
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
                                                        Name = "lime",
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
        };
    }
}
