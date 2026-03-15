using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;
using LittleFootCook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LittleFootCook.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LittleFootCookDbContext _context;

        public CategoryRepository(LittleFootCookDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category(dto.Name);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new CategoryDto(category.Id, category.Name);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Select(c => new CategoryDto(
                c.Id,
                c.Name)).ToListAsync();

            return categories;
        }
    }
}
