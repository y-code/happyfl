using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HappyFL.DB.RecipeManagement
{
    [Table("dish_tag", Schema = "recipe_management")]
    public class DishTag
    {
        [Column("dish_tag_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Column("dish_id")]
        [JsonIgnore]
        public Dish Dish { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
