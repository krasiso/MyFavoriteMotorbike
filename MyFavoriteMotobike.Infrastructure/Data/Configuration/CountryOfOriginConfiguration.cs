using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    internal class CountryOfOriginConfiguration : IEntityTypeConfiguration<CountryOfOrigin>
    {
        public void Configure(EntityTypeBuilder<CountryOfOrigin> builder)
        {
            builder.HasData(CreateCountriesOfOrigin());
        }

        private static List<CountryOfOrigin> CreateCountriesOfOrigin()
        {
            List<CountryOfOrigin> countriesOfOrigin = new List<CountryOfOrigin>()
            {
                new CountryOfOrigin()
                {
                    Id = 1,
                    Name = "Japan"
                },

                new CountryOfOrigin()
                {
                    Id = 2,
                    Name = "Austria"
                },

                new CountryOfOrigin()
                {
                    Id = 3,
                    Name = "Italy"
                },
                new CountryOfOrigin()
                {
                    Id = 4,
                    Name = "Germany"
                },
                new CountryOfOrigin()
                {
                    Id = 5,
                    Name = "Great Britain"
                },
                new CountryOfOrigin()
                {
                    Id = 6,
                    Name = "Sweden"
                }
            };

            return countriesOfOrigin;
        }
    }
}
