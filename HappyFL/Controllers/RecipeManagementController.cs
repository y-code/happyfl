using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HappyFL.DB;
using System.Collections.Generic;
using System.Linq;

namespace HappyFL.Controllers
{
	[Route("api/[controller]")]
	public class RecipeManagementController : Controller
	{
        protected HappyFLDbContext _dbContext;

		ILogger<RecipeManagementController> _logger;

		public RecipeManagementController(ILogger<RecipeManagementController> logger, HappyFLDbContext dbContext)
		{
			_logger = logger;
            _dbContext = dbContext;
		}

	    public class Dish
	    {
            public long Id { get; set; }
		    public string Name { get; set; }
		    public string Cuisine { get; set; }
		    public int NumberOfRecipes { get; set; }
            public Dish(HappyFL.DB.RecipeManagement.Dish d)
            {
                Id = d.Id;
                Name = d.Name;
                Cuisine = d.Cuisine;
                NumberOfRecipes = d.Recipes?.Count ?? 0;
            }
        }

		[HttpGet("[action]")]
		public IEnumerable<Dish> Dishes()
		{
			return _dbContext.Dishes
                .Include(d => d.Recipes)
                .Select(d => new Dish(d));
		}

        public class RecipesForm
        {
            public long DishId { get; set; }
        }

        public class Recipe
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string UrlOfBase { get; set; }
            public Dish Dish { get; set; }
            public IEnumerable<Ingredient> Ingredients { get; set; }
            public Recipe(HappyFL.DB.RecipeManagement.Recipe r)
            {
                Id = r.Id;
                Name = r.Name;
                UrlOfBase = r.UrlofBase;
                Dish = r.Dish == null ? null : new Dish(r.Dish);
                Ingredients = r.Ingredients?.Select(i => new Ingredient(i));
            }
        }
        public class Ingredient
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public float? Amount { get; set; }
            public string Unit { get; set; }
            public string Note { get; set; }
            public IngredientSection Section { get; set; }
            public Ingredient(HappyFL.DB.RecipeManagement.Ingredient i)
            {
                Id = i.Id;
                Name = i.Name;
                Amount = i.Amount;
                Unit = i.Unit;
                Note = i.Note;
                Section = i.Section == null ? null : new IngredientSection(i.Section);
            }
        }
        public class IngredientSection
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public IngredientSection(HappyFL.DB.RecipeManagement.IngredientSection s)
            {
                Id = s.Id;
                Name = s.Name;
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<Recipe> Recipes(RecipesForm form)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.Dish.Id == form.DishId)
                .Include(r => r.Dish)
                .Include(r => r.Ingredients)
                .Select(r => new Recipe(r));
            var test = recipes.ToList();
            return recipes;
        }
	}
}
