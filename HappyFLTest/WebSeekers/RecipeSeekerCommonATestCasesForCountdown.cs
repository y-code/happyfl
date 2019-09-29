using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

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
                                                Name = "wholegrain bread",
                                                Amount = 4f,
                                                Unit = "slice",
                                                Note = "crusts removed",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "Ingredients",
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
                                                Name = "spreadable cream cheese",
                                                Amount = 50f,
                                                Unit = "g",
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
                                                    Name = "Ingredients",
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
                                                Name = "tuna in springwater",
                                                Amount = 95f,
                                                Unit = "g",
                                                Note = "flaked and drained",
                                            },
                                            new Ingredient
                                            {
                                                Name = "springwater",
                                                Amount = 1f,
                                                Unit = "inch",
                                                Note = "flaked and drained, 95 g tuna",
                                            },
                                            new Ingredient
                                            {
                                                Name = "95 g tuna",
                                                Amount = 1f,
                                                Unit = "inch",
                                                Note = "springwater, flaked and drained",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "Ingredients",
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
                                                Name = "lebanese cucumber",
                                                Amount = 0.5f,
                                                Unit = null,
                                                Note = "deseeded and cut into matchsticks",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "Ingredients",
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
                                                Name = "medium carrot",
                                                Amount = 0.25f,
                                                Unit = null,
                                                Note = "cut into matchsticks",
                                            },
                                        },
                                        Section = new ScannedIngredientSection
                                        {
                                            Id = -1,
                                            Candidates = new List<IngredientSection>
                                            {
                                                new IngredientSection
                                                {
                                                    Name = "Ingredients",
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
