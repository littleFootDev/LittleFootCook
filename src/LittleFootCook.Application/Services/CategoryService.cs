using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;
using LittleFootCook.Application.Interfaces;

namespace LittleFootCook.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) { _categoryRepository = categoryRepository; }
        public Task<CategoryDto> CreateAsync(CreateCategoryDto dto) => _categoryRepository.CreateAsync(dto);
       

        public Task DeleteAsync(Guid id) => _categoryRepository.DeleteAsync(id);
        

        public Task<IEnumerable<CategoryDto>> GetAllAsync() => _categoryRepository.GetAllAsync();
        
    }
}
