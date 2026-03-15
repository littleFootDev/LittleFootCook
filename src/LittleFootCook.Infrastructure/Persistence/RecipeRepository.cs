using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;
using LittleFootCook.Domain;
using LittleFootCook.Domain.Entities;
using LittleFootCook.Domain.Enums;
using LittleFootCook.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LittleFootCook.Infrastructure.Persistence
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly LittleFootCookDbContext  _context;
        public RecipeRepository(LittleFootCookDbContext context)
        {
            _context = context;
        }
        public async Task<RecipeDto> CreateAsync(CreateRecipeDto dto)
        {
            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
                throw new LittleFootCookExeption("Catégorie introuvable");

            var prepTime = new Duration(dto.PreparationTimeValue, Enum.Parse<TimeUnit>(dto.PreparationTimeUnit));
            var cookTime = new Duration(dto.CookingTimeValue, Enum.Parse<TimeUnit>(dto.CookingTimeUnit));

            var recipe = new Recipe(
                dto.Title,
                dto.Description,
                Enum.Parse<DifficultyLevel>(dto.Difficulty),
                prepTime,
                cookTime,
                category
                );

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return new RecipeDto(
                recipe.Id,
                recipe.Title,
                recipe.Description,
                recipe.Difficulty.ToString(),
                recipe.PreparationTime.Value,
                recipe.CookingTime.Value,
                recipe.Category.Name,
                new List<IngredientDto>()
                );
        }

        public async Task DeleteAsync(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return;
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeDto>> GetAllAsync()
        {
            var recipes = await _context.Recipes
        .Include(r => r.Category)        // ← charge la Category
        .Include(r => r.Ingredients)     // ← charge les Ingredients
        .Select(r => new RecipeDto(
            r.Id,
            r.Title,
            r.Description,
            r.Difficulty.ToString(),
            r.PreparationTime.Value,
            r.CookingTime.Value,
            r.Category.Name,
            r.Ingredients.Select(i => new IngredientDto(
                i.Name,
                i.Quantity.Value,
                i.Quantity.MeasureUnit.ToString()
            )).ToList()
        ))
        .ToListAsync();
            return recipes;
        }

        public async Task<RecipeDto?> GetByIdAsync(Guid id)
        {
           var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);

            if(recipe == null) return null;

            return new RecipeDto(
                recipe.Id,
                recipe.Title,
                recipe.Description,
                recipe.Difficulty.ToString(),
                recipe.PreparationTime.Value,
                recipe.CookingTime.Value,
                recipe.Category.Name,
                recipe.Ingredients.Select(i => new IngredientDto(
                    i.Name,
                    i.Quantity.Value,
                    i.Quantity.MeasureUnit.ToString()
                    )).ToList()
                );
        }
    }
}
