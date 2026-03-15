
using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Application.Interfaces;
using LittleFootCook.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LittleFootCook.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();

            return services;
        }
    }
}
