using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(CreateBrands());
        }

        private static List<Brand> CreateBrands()
        {
            List<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                    Id = 1,
                    Name = "Kawasaki"
                },

                new Brand()
                {
                    Id = 2,
                    Name = "Honda"
                },

                new Brand()
                {
                    Id = 3,
                    Name = "Yamaha"
                },
                new Brand()
                {
                    Id = 4,
                    Name = "Suzuki"
                },
                new Brand()
                {
                    Id = 5,
                    Name = "KTM"
                },
                new Brand()
                {
                    Id = 6,
                    Name = "Beta"
                },
                new Brand()
                {
                    Id = 7,
                    Name = "BMW"
                },
                new Brand()
                {
                    Id = 8,
                    Name = "Triumph"
                },
                new Brand()
                {
                    Id = 9,
                    Name = "Husaberg"
                }
            };

            return brands;
        }
    }
}
