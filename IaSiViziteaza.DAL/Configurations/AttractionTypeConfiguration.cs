using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL.Configurations
{
    class AttractionTypeConfiguration : IEntityTypeConfiguration<AttractionType>
    {
        public void Configure(EntityTypeBuilder<AttractionType> builder)
        {
            builder.ToTable("AttractionType");
            builder.HasKey(attractionType => attractionType.Id);
            builder.Property(attractionType => attractionType.Title)
                .HasMaxLength(25);
            builder.Property(attractionType => attractionType.Description)
                .HasMaxLength(250);
            builder.HasMany<Attraction>(attraction => attraction.Attractions)
                .WithOne(attractionType => attractionType.AttractionType)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
