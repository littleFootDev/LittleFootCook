using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;

namespace LittleFootCook.API.Endpoints
{
    public static class RecipeEndpoints
    {
        public static void MapRecipeEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/recipes");

            group.MapGet("/", GetAllRecipes);
            group.MapGet("/{id:guid}", GetRecipeById);
            group.MapPost("/", CreateRecipe);
            group.MapDelete("/{id:guid}", DeleteRecipe);
        }

        private static async Task<IResult> GetAllRecipes(IRecipeService service)
        {
            var recipes = await service.GetAllAsync();
            return Results.Ok(recipes);
        }

        private static async Task<IResult> GetRecipeById(Guid id, IRecipeService service)
        {
            var recipe = await service.GetByIdAsync(id);
            return recipe is null
                ? Results.NotFound()
                : Results.Ok(recipe);
        }

        private static async Task<IResult> CreateRecipe(CreateRecipeDto dto, IRecipeService service)
        {
            var recipe = await service.CreateAsync(dto);
            return Results.Created($"/api/recipes/{recipe.Id}", recipe);
        }

        private static async Task<IResult> DeleteRecipe(Guid id, IRecipeService service)
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        }
    }
}

