using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyFL.DB.RecipeManagement
{
    [Table("dish", Schema = "recipe_management")]
    public class Dish
    {
        [Column("dish_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public ICollection<DishTag> Tags { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
