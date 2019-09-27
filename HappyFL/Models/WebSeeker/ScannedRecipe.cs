using System;
using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;

namespace HappyFL.Models.WebSeeker
{
    public class ScannedRecipe
    {
        public long Id { get; set; }
        public List<string> Names { get; set; } = new List<string>();
        public List<ScannedIngredient> Ingredients { get; set; } = new List<ScannedIngredient>();
    }

    public class ScannedIngredientSection
    {
        public long Id { get; set; }
        public List<IngredientSection> Candidates { get; set; } = new List<IngredientSection>();
    }

    public class ScannedIngredient
    {
        public long Id { get; set; }
        public string Input { get; set; }
        public List<Ingredient> Candidates { get; set; } = new List<Ingredient>();
        public ScannedIngredientSection Section { get; set; }
    }
}
