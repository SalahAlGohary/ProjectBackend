using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.HasData(
            //    new Role
            //    {
            //        Id = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
            //        Name = "User",
            //        NormalizedName = "USER"
            //    },
            //    new Role
            //    {
            //        Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
            //        Name = "Administrator",
            //        NormalizedName = "ADMINISTRATOR"
            //    }
            //    ,
            //       new Role
            //       {
            //           Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ddbbf"),
            //           Name = "Company",
            //           NormalizedName = "COMPANY"
            //       }
            //); ;
        }
    }
}
