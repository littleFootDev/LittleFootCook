using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.Interfaces;
using LittleFootCook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LittleFootCook.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LittleFootCookDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("LittleFootCookConnectionString")));

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
