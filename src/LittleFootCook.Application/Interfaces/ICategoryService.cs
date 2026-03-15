using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.DTOs;

namespace LittleFootCook.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
