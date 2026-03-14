using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record CreateRecipeDto
    (
        string Title,
        string Description,
        string Difficulty,
        int PreparationTimeValue,
        string PreparationTimeUnit,
        int CookingTimeValue,
        string CookingTimeUnit,
        Guid CategoryId
    );
}
