using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    internal class CategoryCongifuration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private static List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Motocross"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Dirt Bike"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Sport Bike"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Touring"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Custom"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Street Fighter"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Dual Sport"
                }
            };

            return categories;
        }
    }
}
