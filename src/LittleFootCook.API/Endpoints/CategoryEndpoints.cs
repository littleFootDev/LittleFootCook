using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;

namespace LittleFootCook.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/categories");

            group.MapGet("/", GetAllCategories);
            group.MapPost("/", CreateCategory).RequireAuthorization();
            group.MapDelete("/{id:guid}", DeleteCategory).RequireAuthorization();
        }

        private static async Task<IResult> GetAllCategories(ICategoryService service)
        {
            var categories = await service.GetAllAsync();
            return Results.Ok(categories);
        }

        private static async Task<IResult> CreateCategory(CreateCategoryDto dto, ICategoryService service)
        {
            var category = await service.CreateAsync(dto);
            return Results.Created($"/api/categories/{category.Id}", category);
        }

        private static async Task<IResult> DeleteCategory(Guid id, ICategoryService service)
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        }
    }
}
