using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using LittleFootCook.Domain.Enums;
using LittleFootCook.Domain.ValueObjects;

namespace LittleFootCook.Domain.Entities
{
    public class Recipe : Entity
    {
        private Recipe() { }
        private List<Ingredient> _ingredients = new();

        public IReadOnlyList<Ingredient> Ingredients => _ingredients;
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DifficultyLevel Difficulty { get; private set; }
        public Duration PreparationTime { get; private set; }
        public Duration CookingTime { get; private set; }
        public Category Category { get; private set; }

        public Recipe(string title, string description, DifficultyLevel difficulty, Duration preparationTime, Duration cookingTime,Category category)
        {
            if (string.IsNullOrEmpty(title)) throw new LittleFootCookExeption("Le Titre ne peux être vide");
            Title = title;
            Description = description;
            Difficulty = difficulty;
            PreparationTime = preparationTime;
            CookingTime = cookingTime;
            Category = category;
        }

        public void AddIngredient(Ingredient ingredient) {
            if (ingredient == null) throw new LittleFootCookExeption("L'ingredient ne peut pas être null");
            _ingredients.Add(ingredient);
        }
        public void UpdateTitle(string title) {
            if (string.IsNullOrEmpty(title)) throw new LittleFootCookExeption("Le nouveau titre ne peux pas être vide");
            
            Title = title; 
        }
    }
}
