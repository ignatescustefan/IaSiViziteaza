using IaSiViziteaza.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base(GetOptions())
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilders)
        {
            modelBuilders.ApplyConfiguration(new LocationConfiguration());
            modelBuilders.ApplyConfiguration(new AttractionTypeConfiguration());
            modelBuilders.ApplyConfiguration(new UserConfiguration());
            modelBuilders.ApplyConfiguration(new AccessRightConfiguration());
            modelBuilders.ApplyConfiguration(new UserAccesRightConfiguration());
            modelBuilders.ApplyConfiguration(new AttractionConfiguration());
            modelBuilders.ApplyConfiguration(new CommentConfiguration());
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<AttractionType> AttractionTypes { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<UserAccessRight> UserAccessRights { get; set; }

        private static DbContextOptions GetOptions()
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=IaSiViziteazaDev;Integrated Security=True")
                .Options;
        }
    }
}
