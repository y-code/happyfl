using System;
namespace HappyFL.Test.WebSeekers
{
    public partial class IngredientItemParserCommonATest
    {
        static object[,] TestCaseSourceForUnit =
        {
            {
                new TestCommonATestCase
                {
                    Input = null,
                    Expected =
                    {
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "",
                    Expected =
                    {
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
                    Input = "2 T allspice berries",
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
                    Input = "2 t allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 2f,
                            Unit = "teaspoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "2 heaped-tablespoon - allspice berries",
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
                    Input = "2 heaped tablespoon - allspice berries",
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
                    Input = "2 heaped_tablespoon - allspice berries",
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
                    Input = "2 tbl. - allspice berries",
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
                    Input = "2-4 tbl - allspice berries",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "allspice berries",
                            Amount = 4f,
                            Unit = "tablespoon",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "2 tbl - allspice berries",
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
                    Input = "pinch of salt",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "salt",
                            Amount = 1f,
                            Unit = "pinch",
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "salt",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "salt",
                            Amount = 1f,
                            Unit = null,
                        },
                    }
                }
            },
            {
                new TestCommonATestCase
                {
                    Input = "1/2 c. (1 stick) butter, softened",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "(1 stick) butter",
                            Amount = 0.5f,
                            Unit = "cup",
                            Note = "softened",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = ") butter",
                            Amount = 1f,
                            Unit = "stick",
                            Note = "softened, 1/2 c. (",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "1/2 c. (",
                            Amount = 1f,
                            Unit = "stick",
                            Note = ") butter, softened",
                        },
                    }
                }
            },
            {
                /* Hyphenation between number and unit */
                new TestCommonATestCase
                {
                    Input = "2 (8-oz.) blocks cream cheese, softened",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "(8 oz.) blocks cream cheese",
                            Amount = 2f,
                            Unit = null,
                            Note = "softened",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = ") blocks cream cheese",
                            Amount = 8f,
                            Unit = "ounce",
                            Note = "softened, 2 (",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "2 (",
                            Amount = 8f,
                            Unit = "ounce",
                            Note = ") blocks cream cheese, softened",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "cream cheese",
                            Amount = 1f,
                            Unit = "block",
                            Note = "softened, 2 (8 oz.)",
                        },
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "2 (8 oz.)",
                            Amount = 1f,
                            Unit = "block",
                            Note = "cream cheese, softened",
                        },
                    }
                }
            },
            /* random sample */
            {
                new TestCommonATestCase
                {
                    Input = "2 clove garlic",
                    Expected =
                    {
                        new TestCommonATestCase.ExpectedResult
                        {
                            Name = "garlic",
                            Amount = 2f,
                            Unit = "clove",
                        },
                    }
                }
            },
        };
    }
}
