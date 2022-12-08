using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    public class GoldenClientConfiguration : IEntityTypeConfiguration<GoldenClient>
    {
        public void Configure(EntityTypeBuilder<GoldenClient> builder)
        {
            builder.HasData(new GoldenClient()
            {
                Id = 1,
                PhoneNumber = "+359877777777",
                UserId = "81693837-9353-4dac-a5f2-4eade35a30f9"
            });
        }
    }
}
