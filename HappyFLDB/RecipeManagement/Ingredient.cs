using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyFL.DB.RecipeManagement
{
    [Table("ingredient", Schema = "recipe_management")]
    public class Ingredient
    {
        [Column("ingredient_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("amount")]
        public float? Amount { get; set; }
        [Column("unit")]
        public string Unit { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [ForeignKey("recipe_id")]
        public Recipe Recipe { get; set; }
        [ForeignKey("ingredient_section_id")]
        public IngredientSection Section { get; set; }
    }
}