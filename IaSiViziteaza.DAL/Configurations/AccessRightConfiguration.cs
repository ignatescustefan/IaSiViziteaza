using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IaSiViziteaza.DAL.Configurations
{
    class AccessRightConfiguration : IEntityTypeConfiguration<AccessRight>
    {
        public void Configure(EntityTypeBuilder<AccessRight> builder)
        {
            builder.ToTable("AccessRight");
            builder.HasKey(accessRight => accessRight.Id);
            //add contraint to priority field
        }
    }
}
