using Microsoft.EntityFrameworkCore;
using HappyFL.DB.RecipeManagement;

namespace HappyFL.DB
{
    public class HappyFLDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public HappyFLDbContext(DbContextOptions<HappyFLDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>();
            modelBuilder.Entity<Recipe>();
            modelBuilder.Entity<Ingredient>();
            modelBuilder.Entity<IngredientSection>();
        }
    }
}
