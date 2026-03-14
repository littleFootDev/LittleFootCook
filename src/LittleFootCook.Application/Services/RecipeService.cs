using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;

namespace LittleFootCook.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository) => _recipeRepository = recipeRepository;

        public Task<RecipeDto> CreateAsync(CreateRecipeDto dto) => _recipeRepository.CreateAsync(dto);
        

        public Task DeleteAsync(Guid id) => _recipeRepository.DeleteAsync(id);


        public Task<IEnumerable<RecipeDto>> GetAllAsync() => _recipeRepository.GetAllAsync();
        

        public Task<RecipeDto?> GetByIdAsync(Guid id) => _recipeRepository.GetByIdAsync(id);
        
    }
}
