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
                },
                new Brand()
                {
                    Id = 10,
                    Name = "Harley Davidson"
                },
                new Brand()
                {
                    Id = 11,
                    Name = "Indian"
                },
                new Brand()
                {
                    Id = 12,
                    Name = "Royal Enfield"
                },
                new Brand()
                {
                    Id = 13,
                    Name = "Husqvarna"
                },
                new Brand()
                {
                    Id = 14,
                    Name = "Ural"
                },
                new Brand()
                {
                    Id = 15,
                    Name = "Gima Motorcycles"
                },
                new Brand()
                {
                    Id = 16,
                    Name = "GasGas"
                },
                new Brand()
                {
                    Id = 17,
                    Name = "Sherco"
                },
                new Brand()
                {
                    Id = 18,
                    Name = "Scorpa"
                },
                new Brand()
                {
                    Id = 19,
                    Name = "Dnepr M-72"
                }
            };

            return brands;
        }
    }
}
