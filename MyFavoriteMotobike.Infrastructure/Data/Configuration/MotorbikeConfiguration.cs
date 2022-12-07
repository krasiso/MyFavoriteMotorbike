using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotobike.Infrastructure.Data.Configuration
{
    internal class MotorbikeConfiguration : IEntityTypeConfiguration<Motorbike>
    {
        public void Configure(EntityTypeBuilder<Motorbike> builder)
        {
            builder.HasData(CreateMotorbikes());
        }

        private List<Motorbike> CreateMotorbikes()
        {
            var motorbikes = new List<Motorbike>()
            {
                new Motorbike()
                {
                    Id = 1,
                    BrandId = 1,
                    Variety = "KX",
                    CubicCentimeters = 250.00M,
                    Description = "This bike is for racing and amateur riding on a motocross track!",
                    ImageUrl = "https://content2.kawasaki.com/ContentStorage/KMC/Products/8711/c5b45b1d-afef-445c-a721-671cf7b09dcb.png?w=850",
                    CategoryId = 1,
                    PricePerDay = 100.00M,
                },
                new Motorbike()
                {
                    Id = 2,
                    BrandId = 2,
                    Variety = "CRF",
                    CubicCentimeters = 450.00M,
                    Description = "This bike is for riding through mountains and off-road terrain!",
                    ImageUrl = "https://www.motowag.com/wp-content/uploads/2022/05/honda-crf450x.jpg",
                    CategoryId = 2,
                    PricePerDay = 100.00M
                },
                new Motorbike()
                {
                    Id = 3,
                    BrandId = 4,
                    Variety = "Hayabusa",
                    CubicCentimeters = 1300.00M,
                    Description = "This bike is for riding on the road and it's one of the fastest bikes ever!",
                    ImageUrl = "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg",
                    CategoryId = 3,
                    PricePerDay = 200.00M,
                },
                new Motorbike()
                {
                    Id = 4,
                    BrandId = 7,
                    Variety = "R1250RT",
                    CubicCentimeters = 1250.00M,
                    Description = "This bike is for long and comfortable riding on the road!",
                    ImageUrl = "https://ultimatemotorcycling.com/wp-content/uploads/2021/07/2022-bmw-r-1250-rt-first-look-sport-touring-motorcycle-10.jpg",
                    CategoryId = 4,
                    PricePerDay = 200.00M
                },
                new Motorbike()
                {
                    Id = 5,
                    BrandId = 8,
                    Variety = "Street Twin",
                    CubicCentimeters = 900.00M,
                    Description = "This bike is for easy riding on the road!",
                    ImageUrl = "https://imgd.aeplcdn.com/1280x720/bw/models/triumph-street-twin-2021-standard20210401131021.jpg?q=80",
                    CategoryId = 5,
                    PricePerDay = 100.00M,
                },
                new Motorbike()
                {
                    Id = 6,
                    BrandId = 3,
                    Variety = "MT-15",
                    CubicCentimeters = 155.00M,
                    Description = "This bike is for riding on the road mostly in the city!",
                    ImageUrl = "https://www.indiacarnews.com/wp-content/uploads/2019/03/Yamaha-MT-15-International.jpg",
                    CategoryId = 6,
                    PricePerDay = 100.00M
                },
                new Motorbike()
                {
                    Id = 7,
                    BrandId = 5,
                    Variety = "Adventure",
                    CubicCentimeters = 990.00M,
                    Description = "This adventure is for almost any terreain!",
                    ImageUrl = "https://mcn-images.bauersecure.com/wp-images/19502/951x634/990_adventure_dakar.jpg?mode=max&quality=90&scale=down",
                    CategoryId = 7,
                    PricePerDay = 100.00M,
                },
                new Motorbike()
                {
                    Id = 8,
                    BrandId = 10,
                    Variety = "Fat Boy",
                    CubicCentimeters = 1868.00M,
                    Description = "This bike outstanding cafe racer!",
                    ImageUrl = "https://www.harley-davidson.com/content/dam/h-d/images/product-images/bikes/motorcycle/2022/2022-fat-boy-114/gallery/2022-fat-boy-114-motorcycle-g2.jpg?impolicy=myresize&rw=820",
                    CategoryId = 9,
                    PricePerDay = 200.00M,
                },
                new Motorbike()
                {
                    Id = 9,
                    BrandId = 11,
                    Variety = "Super Chief",
                    CubicCentimeters = 1811.00M,
                    Description = "This bike is greatest chief of indians!",
                    ImageUrl = "https://www.webbikeworld.com/wp-content/uploads/2022/07/2022-Indian-Scout-Bobber-Sixty-4.jpg",
                    CategoryId = 9,
                    PricePerDay = 200.00M,
                },
                new Motorbike()
                {
                    Id = 10,
                    BrandId = 6,
                    Variety = "RR300 2T",
                    CubicCentimeters = 300.00M,
                    Description = "This bike is magnificent mountain climber!",
                    ImageUrl = "https://enduro21.com/images/2021/november-2021/2022-beta-300-rx/2022_beta_300_rx_1.jpg",
                    CategoryId = 2,
                    PricePerDay = 100.00M,
                }
            };

            return motorbikes;
        }
    }
}
