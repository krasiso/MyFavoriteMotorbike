using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "81693837-9353-4dac-a5f2-4eade35a30f9",
                UserName = "administrator@mail.com",
                NormalizedUserName = "administrator@mail.com",
                Email = "administrator@mail.com",
                NormalizedEmail = "administrator@mail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "agent123");

            users.Add(user);

            user = new User()
            {
                Id = "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "guest123");

            users.Add(user);

            return users;
        }
    }
}
