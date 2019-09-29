using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

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
                                                Name = "(20 ounce) package chocolate sandwich cookies",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                            new Ingredient
                                            {
                                                Name = ") package chocolate sandwich cookies",
                                                Amount = 20f,
                                                Unit = "ounce",
                                                Note = "1 (",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1 (",
                                                Amount = 20f,
                                                Unit = "ounce",
                                                Note = ") package chocolate sandwich cookies",
                                            },
                                            new Ingredient
                                            {
                                                Name = "chocolate sandwich cookies",
                                                Amount = 1f,
                                                Unit = "package",
                                                Note = "1 (20 ounce)",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1 (20 ounce)",
                                                Amount = 1f,
                                                Unit = "package",
                                                Note = "chocolate sandwich cookies",
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
                                                Name = "margarine",
                                                Amount = 0.5f,
                                                Unit = "cup",
                                                Note = "melted",
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
                                                Name = "chopped Spanish peanuts",
                                                Amount = 1.5f,
                                                Unit = "cup",
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
                                                Name = "vanilla ice cream",
                                                Amount = 0.5f,
                                                Unit = "gallon",
                                                Note = "softened",
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
                                                Name = "confectioners ' sugar",
                                                Amount = 2f,
                                                Unit = "cup",
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
                                                Name = "(12fluid ounce) can evaporated milk",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = null,
                                            },
                                            new Ingredient
                                            {
                                                Name = ") can evaporated milk",
                                                Amount = 12f,
                                                Unit = "fl oz",
                                                Note = "1 (",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1 (",
                                                Amount = 12f,
                                                Unit = "fl oz",
                                                Note = ") can evaporated milk",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "semisweet chocolate chips",
                                                Amount = 0.6666667f,
                                                Unit = "cup",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "margarine",
                                                Amount = 0.5f,
                                                Unit = "cup",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                            Id = -2,
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
            {
                new TestFindRecipeTestCase
                {
                    Url = "https://www.allrecipes.com/recipe/143082/sweet-sticky-and-spicy-chicken/?internalSource=previously%20viewed&referringContentType=Homepage&clickId=cardslot%202",
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
                                                Name = "water",
                                                Amount = 0.5f,
                                                Unit = "cup",
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
                                                Name = "low-sodium chicken broth",
                                                Amount = 0.3333333f,
                                                Unit = "cup",
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
                                                Name = "ketchup",
                                                Amount = 0.25f,
                                                Unit = "cup",
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
                                                Name = "low-sodium soy sauce",
                                                Amount = 0.25f,
                                                Unit = "cup",
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
                                                Name = "honey",
                                                Amount = 0.25f,
                                                Unit = "cup",
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
                                                Name = "garlic",
                                                Amount = 2f,
                                                Unit = "clove",
                                                Note = "crushed",
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
                                                Name = "rice vinegar",
                                                Amount = 1f,
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
                                                Name = "Sriracha sauce",
                                                Amount = 2f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "sesame oil",
                                                Amount = 2f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "grated fresh ginger root",
                                                Amount = 1f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "crushed red pepper flakes",
                                                Amount = 0.25f,
                                                Unit = "teaspoon",
                                                Note = "or to taste",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "boneless chicken breast",
                                                Amount = 4f,
                                                Unit = null,
                                                Note = "cut into bite-size pieces",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
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
                                                Name = "water",
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
                                            },
                                        },
                                    },
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "cornstarch",
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
