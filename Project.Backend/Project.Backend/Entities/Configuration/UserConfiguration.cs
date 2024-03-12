using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Backend.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.ToTable("AspNetUsers");
            builder
             .Property(c => c.Name)
             .HasMaxLength(500);
            builder
             .Property(c => c.PhotoUrl)
             .HasMaxLength(1000);


            //builder
            //.Property(c => c.Vcode)
            //      .HasMaxLength(10);

            //    builder
            //   .Property(e => e.ExpirationVCodeDate)
            //.HasConversion(v => v, v => DateTime.SpecifyKind(v.Value, DateTimeKind.Unspecified));
            //.HasColumnType("timestamp") // Set the PostgreSQL data type
            //.HasColumnType("timestamp without time zone");

            //// Ensure DateTimeKind is set to DateTimeKind.Utc for the property
            //builder
            //    .Property(e => e.ExpirationVCodeDate)
            //    .HasConversion(
            //        v => v, // Value to database
            //        v => DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) // Database to value
            //    );
            //        builder
            //.Property(e => e.BirthDate)
            //.HasColumnType("timestamp") // Set the PostgreSQL data type
            //.HasColumnType("timestamp without time zone");

            //// Ensure DateTimeKind is set to DateTimeKind.Utc for the property
            //builder
            //    .Property(e => e.BirthDate)
            //    .HasConversion(
            //        v => v, // Value to database
            //        v => DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) // Database to value
            //    );
            builder.HasData(
                 new User
                 {
                     Id = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     Name = "System Admin",
                     UserName = "admin@localhost.com",
                     PhoneNumber = "224466889",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
            //,
            //new User
            //{
            //    Id = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
            //    Email = "user@localhost.com",
            //    NormalizedEmail = "USER@LOCALHOST.COM",
            //    FirstName = "System",
            //    LastName = "User",
            //    UserName = "user@localhost.com",
            //    NormalizedUserName = "USER@LOCALHOST.COM",
            //    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            //    EmailConfirmed = true
            //}
            );

        }

    }

}
