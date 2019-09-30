using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HappyFL.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using HappyFL.DB.RecipeManagement;

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

		[HttpGet("[action]")]
		public IEnumerable<Dish> Dishes()
		{
			return _dbContext.Dishes
                .Include(d => d.Recipes);
		}

        public class RecipesForm
        {
            public long DishId { get; set; }
        }

        [HttpGet("[action]")]
        public IEnumerable<Recipe> Recipes(RecipesForm form)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.Dish.Id == form.DishId)
                .Include(r => r.Dish)
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Section)
                .OrderBy(r => r.Id)
                .ToList();
            foreach (var recipe in recipes)
            {
                recipe.Ingredients = recipe.Ingredients
                    .OrderBy(i => i.Section.Id)
                    .ThenBy(i => i.Id)
                    .ToList();
            }
            return recipes;
        }

        public class SaveRecipeResult
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }

        [HttpPost("[action]")]
        public async Task<SaveRecipeResult> SaveRecipe([FromBody] DB.RecipeManagement.Recipe recipe)
        {
            if (recipe.Id < 0)
                recipe.Id = null;
            var sections = recipe.Ingredients
                .Select(i => i.Section)
                .GroupBy(s => s.Id)
                .Select(g => g.First());
            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient.Id < 0)
                    ingredient.Id = null;
                ingredient.Section = sections
                    .FirstOrDefault(s => s.Id == ingredient.Section.Id);
            }
            foreach (var section in sections)
                if (section.Id < 0)
                    section.Id = null;

            try
            {

                _dbContext.AddRange(sections);
                _dbContext.SaveChanges();

                if (recipe?.Id == null)
                    _dbContext.Add(recipe);
                else
                    _dbContext.Update(recipe);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to save a recipe {@recipe}. {@exception}", recipe, e);
                return new SaveRecipeResult
                {
                    IsSuccess = false,
                    Message = "Failed to save the recipe.",
                };
            }

            return new SaveRecipeResult
            {
                IsSuccess = true,
                Message = "The recipe has been successfully saved.",
            };
        }
    }
}
