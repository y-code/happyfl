using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class IngredientItemParserCommonATest
    {
        static object[,] TestCaseSourceForAmount =
        {
            {
                new TestCommonATestCase
                {
                    Input = "2 * three tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 6f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "two * 3 tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 6f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "a half of tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 0.5f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "a couple of tablespoons - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 2f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "1 tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 1f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "2 Tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 2f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "1 1/2 Tablespoon - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 1.5f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "½ a fresh red chilli",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "fresh red chilli",
                            Amount = 0.5f,
                            Unit = null,
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "½ A fresh red chilli",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "fresh red chilli",
                            Amount = 0.5f,
                            Unit = null,
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "450g fruit, chopped into 1cm chunks (we used 400g Bramley apples and 50g fresh blackberries)",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "fruit",
                            Amount = 450f,
                            Unit = "g",
                            Note = "chopped into 1 cm chunks (we used 400 g Bramley apples and 50 g fresh blackberries)",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "chunks (we used 400 g Bramley apples and 50 g fresh blackberries)",
                            Amount = 1f,
                            Unit = "cm",
                            Note = "450 g fruit, chopped into",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "450 g fruit, chopped into",
                            Amount = 1f,
                            Unit = "cm",
                            Note = "chunks (we used 400 g Bramley apples and 50 g fresh blackberries)",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "Bramley apples and 50 g fresh blackberries)",
                            Amount = 400f,
                            Unit = "g",
                            Note = "450 g fruit, chopped into 1 cm chunks (we used",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "450 g fruit, chopped into 1 cm chunks (we used",
                            Amount = 400f,
                            Unit = "g",
                            Note = "Bramley apples and 50 g fresh blackberries)",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "fresh blackberries)",
                            Amount = 50f,
                            Unit = "g",
                            Note = "450 g fruit, chopped into 1 cm chunks (we used 400 g Bramley apples and",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "450 g fruit, chopped into 1 cm chunks (we used 400 g Bramley apples and",
                            Amount = 50f,
                            Unit = "g",
                            Note = "fresh blackberries)",
                        },
                    }
                }
            },
        };
    }
}
