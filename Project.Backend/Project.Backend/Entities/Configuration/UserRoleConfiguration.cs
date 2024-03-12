using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    RoleId = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                    UserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
                //,new UserRole
                //{
                //    RoleId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                //    UserId = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9")
                //}
            );
        }
    }
}
