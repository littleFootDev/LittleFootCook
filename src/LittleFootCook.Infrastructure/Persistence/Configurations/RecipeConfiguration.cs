using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleFootCook.Infrastructure.Persistence.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Description)
                .HasMaxLength(2000);

            
            builder.OwnsOne(r => r.PreparationTime, d =>
            {
                d.Property(x => x.Value).HasColumnName("PreparationTimeValue");
                d.Property(x => x.TimeUnit).HasColumnName("PreparationTimeUnit");
            });

            builder.OwnsOne(r => r.CookingTime, d =>
            {
                d.Property(x => x.Value).HasColumnName("CookingTimeValue");
                d.Property(x => x.TimeUnit).HasColumnName("CookingTimeUnit");
            });

            builder.HasOne(r => r.Category)
                .WithMany()
                .HasForeignKey("CategoryId");

            builder.HasMany(r => r.Ingredients)
                .WithOne()
                .HasForeignKey("RecipeId");
        }
    }
    }
