using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IaSiViziteaza.DAL.Configurations
{
    public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
            builder.ToTable("Attraction");
            builder.HasOne<Location>(location => location.Location)
                .WithOne(attraction => attraction.Attraction)
                .HasForeignKey<Location>(location => location.LocationOfAttractionId);
            builder.HasMany<Comment>(comment => comment.Comments)
                .WithOne(attraction => attraction.Attraction)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
