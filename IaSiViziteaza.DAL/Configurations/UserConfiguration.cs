using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);

            builder.HasMany<Attraction>(attraction => attraction.Attractions)
                .WithOne(user => user.User)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<Comment>(comment => comment.Comments)
                .WithOne(user => user.User);
                //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
