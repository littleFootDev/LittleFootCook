using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleFootCook.Infrastructure.Persistence.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(r => r.Quantity, d =>
            {
                d.Property(x => x.Value).HasColumnName("QuantityValue");
                d.Property(x => x.MeasureUnit).HasColumnName("QuantityUnit");
            });
        }
    }
}
