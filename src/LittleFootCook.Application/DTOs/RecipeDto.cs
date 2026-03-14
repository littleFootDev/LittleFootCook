using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record RecipeDto(
        Guid Id,
        string Title,
        string Description,
        string Difficulty,
        int PreparationTime,
        int CookingTime,
        string CategoryName,
        IReadOnlyList<IngredientDto> Ingredients
    );
    
}
