using System;
using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;

namespace HappyFL.Models.WebSeeker
{
    public class RecipeSeekResult
    {
        public List<string> Names { get; set; } = new List<string>();
        public List<IngredientsSection> IngredientsSections { get; set; } = new List<IngredientsSection>();
        public class IngredientsSection
        {
            public List<string> Names { get; set; } = new List<string>();
            public List<IngredientItem> Ingredients { get; set; } = new List<IngredientItem>();
        }

        public class IngredientItem
        {
            public string Input { get; set; }
            public List<Ingredient> Candidates { get; set; } = new List<Ingredient>();
        }
    }
}
