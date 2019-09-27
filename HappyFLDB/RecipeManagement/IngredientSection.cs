using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyFL.DB.RecipeManagement
{
    [Table("ingredient_section", Schema = "recipe_management")]
    public class IngredientSection
    {
        [Column("ingredient_section_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}