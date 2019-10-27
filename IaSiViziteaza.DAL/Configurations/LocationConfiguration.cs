using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(location => location.Id);

            builder.HasOne<Attraction>(attraction => attraction.Attraction)
                .WithOne(location => location.Location)
                .HasForeignKey<Location>(location => location.Id);
        }
    }
}
