using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class RecipeSeekerTest
    {
        static object[,] TestCaseSourceForCountdown =
        {
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.countdown.co.nz/recipes/2118/tuna-sushi-style-sandwiches",
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
                                            "Ingredients",
                                        },
                                        Ingredients =
                                        {
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "wholegrain bread",
                                                        Amount = 4f,
                                                        Unit = "slice",
                                                        Note = "crusts removed",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "spreadable cream cheese",
                                                        Amount = 50f,
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
                                                        Name = "tuna in springwater",
                                                        Amount = 95f,
                                                        Unit = "g",
                                                        Note = "flaked and drained",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "springwater",
                                                        Amount = 1f,
                                                        Unit = "inch",
                                                        Note = "flaked and drained, 95 g tuna",
                                                    },
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "95 g tuna",
                                                        Amount = 1f,
                                                        Unit = "inch",
                                                        Note = "springwater, flaked and drained",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "lebanese cucumber",
                                                        Amount = 0.5f,
                                                        Unit = null,
                                                        Note = "deseeded and cut into matchsticks",
                                                    },
                                                }
                                            },
                                            new TestFindRecipeTestCase.ExpectedIngredientItem
                                            {
                                                Candidates =
                                                {
                                                    new TestFindRecipeTestCase.ExpectedIngredientCandidate
                                                    {
                                                        Name = "medium carrot",
                                                        Amount = 0.25f,
                                                        Unit = null,
                                                        Note = "cut into matchsticks",
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
