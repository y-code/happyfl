using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyFL.DB.RecipeManagement
{
    [Table("recipe", Schema = "recipe_management")]
    public class Recipe
    {
        [Column("recipe_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("servings")]
        public int Servings { get; set; }
        [Column("url_of_base")]
        public string UrlOfBase { get; set; }
        [ForeignKey("dish_id")]
        public Dish Dish { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
