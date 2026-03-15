using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LittleFootCook.Infrastructure.Persistence
{
    public class LittleFootCookDbContext : DbContext
    {
        public LittleFootCookDbContext(DbContextOptions<LittleFootCookDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LittleFootCookDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
