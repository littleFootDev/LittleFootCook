using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;
using LittleFootCook.Application.Services;
using LittleFootCook.Domain.Entities;
using Moq;

namespace LittleFootCook.Tests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IRecipeRepository> _mockRepository;
        private readonly RecipeService _service;

        public RecipeServiceTests()
        {
            _mockRepository = new Mock<IRecipeRepository>();
            _service = new RecipeService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllRecipes()
        {
            // Arrange
            var recipes = new List<RecipeDto>
            {
                new RecipeDto(Guid.NewGuid(), "Pizza", "Desc", "Easy", 15, 20, "Plats", new List<IngredientDto>()),
                new RecipeDto(Guid.NewGuid(), "Pasta", "Desc", "Easy", 10, 15, "Plats", new List<IngredientDto>())
            };
            _mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(recipes);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsRecipe()
        {
            var recipeId = Guid.NewGuid();
            var recipe = new RecipeDto(recipeId, "Pizza", "Desc", "Easy", 15, 20, "Plats", new List<IngredientDto>());
            _mockRepository.Setup(r => r.GetByIdAsync(recipeId))
                .ReturnsAsync(recipe);

            var result = await _service.GetByIdAsync(recipeId);

            Assert.NotNull(result);
            Assert.Equal(recipeId, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            _mockRepository.Setup(r => r.GetByIdAsync(recipeId))
                .ReturnsAsync((RecipeDto)null);

            // Act
            var result = await _service.GetByIdAsync(recipeId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAsync_ValidDto_ReturnsCreatedRecipe()
        {
            var newRecipe = new CreateRecipeDto("Burger", "Miam", "Easy", 10, "Minutes", 5, "Minutes", Guid.NewGuid());

            _mockRepository.Setup(r => r.CreateAsync(It.IsAny<CreateRecipeDto>()))
                .ReturnsAsync(new RecipeDto(Guid.NewGuid(), "Burger", "Miam", "Easy", 10, 5, "Plats", new List<IngredientDto>()));

            var result = await _service.CreateAsync(newRecipe);

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
            _mockRepository.Verify(r => r.CreateAsync(It.IsAny<CreateRecipeDto>()), Times.Once);
        }
    }
}
