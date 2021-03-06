﻿using Microsoft.AspNetCore.Mvc;
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
            public long? DishId { get; set; }
            public long? RecipeId { get; set; }
        }

        [HttpGet("[action]")]
        public IEnumerable<Recipe> Recipes(RecipesForm form)
        {
            List<Recipe> recipes;
            if (form.RecipeId.HasValue)
                recipes = _dbContext.Recipes
                    .Where(r => r.Id == form.RecipeId)
                    .Include(r => r.Dish)
                    .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Section)
                    .OrderBy(r => r.Id)
                    .ToList();
            else if (form.DishId.HasValue)
                recipes = _dbContext.Recipes
                    .Where(r => r.Dish.Id == form.DishId)
                    .Include(r => r.Dish)
                    .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Section)
                    .OrderBy(r => r.Id)
                    .ToList();
            else
                recipes = new List<Recipe>();

            foreach (var recipe in recipes)
            {
                recipe.Ingredients = recipe.Ingredients
                    .OrderBy(i => i.Section?.Id ?? 0)
                    .ThenBy(i => i.Id)
                    .ToList();
            }

            return recipes;
        }

        public class SaveRecipeResult
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public long? RecipeId { get; set; }
            public long? DishId { get; set; }
        }

        [HttpPost("[action]")]
        public async Task<SaveRecipeResult> Recipes([FromBody] Recipe recipe)
        {
            PrepareForPersistence(recipe, out var sections);

            try
            {
                if (sections.Any(s => s.Id.HasValue))
                    _dbContext.UpdateRange(sections.Where(s => s.Id.HasValue));
                if (sections.Any(s => !s.Id.HasValue))
                    _dbContext.AddRange(sections.Where(s => !s.Id.HasValue));
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
                RecipeId = recipe.Id,
                DishId = recipe.Dish?.Id,
            };
        }

        private void PrepareForPersistence(Recipe recipe, out IEnumerable<IngredientSection> sections)
        {
            if (recipe.Id < 0)
                recipe.Id = null;
            sections = recipe.Ingredients
                .Where(i => i.Section != null)
                .Select(i => i.Section)
                .GroupBy(s => s.Id)
                .Select(g => g.First());
            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient.Id < 0)
                    ingredient.Id = null;
                if (ingredient.Section != null)
                    ingredient.Section = sections
                        .FirstOrDefault(s => s.Id == ingredient.Section.Id);
            }
            foreach (var section in sections)
                if (section.Id < 0)
                    section.Id = null;
        }
    }
}
