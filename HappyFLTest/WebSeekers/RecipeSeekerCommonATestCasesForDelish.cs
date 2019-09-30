using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

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
                            new ScannedRecipe
                            {
                                Id = -1,
                                Servings = 4,
                                Dish = new ScannedDish
                                {
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {
                                        new Dish
                                        {
                                            Name = "Coconut Chicken Tenders"
                                        },
                                    },
                                },
                                Ingredients = new List<ScannedIngredient>
                                {
                                    new ScannedIngredient
                                    {
                                        Candidates = new List<Ingredient>
                                        {
                                            new Ingredient
                                            {
                                                Name = "Cooking spray",
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
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "packed sweetened shredded coconut",
                                                Amount = 3f,
                                                Unit = "cup",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "extra-virgin olive oil",
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
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "large eggs",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "boneless skinless chicken breasts",
                                                Amount = 1f,
                                                Unit = "pound",
                                                Note = "cut into bite-sized pieces",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "kosher salt",
                                                Amount = 0.5f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "all-purpose flour",
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
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                                                Name = "Heinz Simply Ketchup",
                                                Amount = 1f,
                                                Unit = null,
                                                Note = "for serving",
                                            },
                                            new Ingredient
                                            {
                                                Name = "Heinz Simply Ketchup, for serving",
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
                                                new IngredientSection
                                                {
                                                    Name = "",
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
                    Url = "https://www.delish.com/cooking/recipe-ideas/a28930153/cookie-monster-cheesecake-bars-recipe/",
                    Expected =
                    {
                        Recipes =
                        {
                            new ScannedRecipe
                            {
                                Id = -1,
                                Servings = 16,
                                Dish = new ScannedDish
                                {
                                    Id = -1,
                                    Candidates = new List<Dish>
                                    {
                                        new Dish
                                        {
                                            Name = "Cookie Monster Cheesecake Bars"
                                        },
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
                                                Name = "Cooking spray",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "(1 stick) butter",
                                                Amount = 0.5f,
                                                Unit = "cup",
                                                Note = "softened",
                                            },
                                            new Ingredient
                                            {
                                                Name = ") butter",
                                                Amount = 1f,
                                                Unit = "stick",
                                                Note = "softened, 1/2 c. (",
                                            },
                                            new Ingredient
                                            {
                                                Name = "1/2 c. (",
                                                Amount = 1f,
                                                Unit = "stick",
                                                Note = ") butter, softened",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "packed brown sugar",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "granulated sugar",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "large egg",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "pure vanilla extract",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "all-purpose flour",
                                                Amount = 1.25f,
                                                Unit = "cup",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "kosher salt",
                                                Amount = 0.5f,
                                                Unit = "teaspoon",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "semisweet chocolate chips",
                                                Amount = 1f,
                                                Unit = "cup",
                                                Note = null,
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the crust",
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
                                                Name = "(8-oz.) blocks cream cheese",
                                                Amount = 2f,
                                                Unit = null,
                                                Note = "softened",
                                            },
                                            new Ingredient
                                            {
                                                Name = "oz.) blocks cream cheese",
                                                Amount = 8f,
                                                Unit = null,
                                                Note = "softened, 2 (",
                                            },
                                            new Ingredient
                                            {
                                                Name = "2 (",
                                                Amount = 8f,
                                                Unit = null,
                                                Note = "oz.) blocks cream cheese, softened",
                                            },
                                            new Ingredient
                                            {
                                                Name = ".) blocks cream cheese",
                                                Amount = 1f,
                                                Unit = "ounce",
                                                Note = "softened, 2 (8-",
                                            },
                                            new Ingredient
                                            {
                                                Name = "2 (8-",
                                                Amount = 1f,
                                                Unit = "ounce",
                                                Note = ".) blocks cream cheese, softened",
                                            },
                                            new Ingredient
                                            {
                                                Name = "cream cheese",
                                                Amount = 1f,
                                                Unit = "block",
                                                Note = "softened, 2 (8-oz.)",
                                            },
                                            new Ingredient
                                            {
                                                Name = "2 (8-oz.)",
                                                Amount = 1f,
                                                Unit = "block",
                                                Note = "cream cheese, softened",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -2,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "For the cheesecake",
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
                                                Name = "sour cream",
                                                Amount = 0.25f,
                                                Unit = "cup",
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
                                                    Name = "For the cheesecake",
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
                                                Name = "granulated sugar",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the cheesecake",
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
                                                Name = "large eggs",
                                                Amount = 3f,
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
                                                    Name = "For the cheesecake",
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
                                                Name = "pure vanilla extract",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the cheesecake",
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
                                                Name = "kosher salt",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the cheesecake",
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
                                                Name = "Blue food coloring",
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
                                                    Name = "For the cheesecake",
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
                                                Name = "mini Chips Ahoy",
                                                Amount = 1f,
                                                Unit = "cup",
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
                                                    Name = "For the cheesecake",
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
                                                Name = "mini Oreos",
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
                                                new IngredientSection
                                                {
                                                    Name = "For the cheesecake",
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
        };
    }
}
