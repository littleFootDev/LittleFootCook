using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;

namespace LittleFootCook.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<RecipeDto>> GetAllAsync();
        Task<RecipeDto> CreateAsync(CreateRecipeDto dto);
        Task DeleteAsync(Guid id);
    }
}
