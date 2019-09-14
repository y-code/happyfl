using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class IngredientItemParserCommonATest
    {
        static object[,] TestCaseSourceForRandom =
        {
            {
                new TestCommonATestCase
                {
                    Input = "4 higher-welfare chicken drumsticks, skin on",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "higher-welfare chicken drumsticks",
                            Amount = 4f,
                            Unit = null,
                            Note = "skin on",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "250g self-raising flour , plus extra for dusting",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "self-raising flour",
                            Amount = 250f,
                            Unit = "g",
                            Note = "plus extra for dusting",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "250 g yoghurt",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "yoghurt",
                            Amount = 250f,
                            Unit = "g",
                            Note = null,
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "½ teaspoon baking powder",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "baking powder",
                            Amount = 0.5f,
                            Unit = "teaspoon",
                            Note = null,
                        },
                    }
                }
            },
        };
    }
}
