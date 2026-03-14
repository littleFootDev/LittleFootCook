using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Application.DTOs
{
    public record IngredientDto
    (
        string Name,
        decimal Quantity,
        string Unit
    );
}
