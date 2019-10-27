using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IaSiViziteaza.DAL.Configurations
{
    class UserAccesRightConfiguration : IEntityTypeConfiguration<UserAccessRight>
    {
        public void Configure(EntityTypeBuilder<UserAccessRight> builder)
        {
            builder.ToTable("UserAccesRight");
            builder.HasKey(userAccessRight => new { userAccessRight.UserId, userAccessRight.AccessRightId });
            builder.HasOne<User>(user => user.User)
                .WithMany(user => user.UserAccessRights)
                .HasForeignKey(userAccessRight => userAccessRight.UserId);
            builder.HasOne<AccessRight>(accessRight => accessRight.AccessRight)
                .WithMany(accessRight => accessRight.UserAccessRights)
                .HasForeignKey(userAccessRight => userAccessRight.AccessRightId);
        }
    }
}
