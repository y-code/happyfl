using System;
using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;

namespace HappyFL.Models.WebSeeker
{
    public class ScannedRecipe
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long? Servings { get; set; }
        public ScannedDish Dish { get; set; }
        public IEnumerable<ScannedIngredient> Ingredients { get; set; }
    }

    public class ScannedDish
    {
        public long? Id { get; set; }
        public IEnumerable<Dish> Candidates { get; set; }
    }

    public class ScannedIngredientSection
    {
        public long? Id { get; set; }
        public IEnumerable<IngredientSection> Candidates { get; set; }
    }

    public class ScannedIngredient
    {
        public long? Id { get; set; }
        public string Input { get; set; }
        public IEnumerable<Ingredient> Candidates { get; set; }
        public ScannedIngredientSection Section { get; set; }
    }
}
