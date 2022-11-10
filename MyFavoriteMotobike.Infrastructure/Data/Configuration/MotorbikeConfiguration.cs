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
                    Model = "KX",
                    CubicCentimeters = 250.00M,
                    Description = "This bike is for racing and amateur riding on a motocross track!",
                    ImageUrl = "https://content2.kawasaki.com/ContentStorage/KMC/ProductTrimGroup/56/1c0de86b-e024-4e09-8ba6-bd08b77344e5.jpg?w=750",
                    CategoryId = 1,
                    PricePerDay = 100.00M,
                    //RenterId = "8b3a06b4-e59d-426d-97ad-b5b27fa8d354"
                },
                new Motorbike()
                {
                    Id = 2,
                    BrandId = 2,
                    Model = "CRF",
                    CubicCentimeters = 450.00M,
                    Description = "This bike is for riding through mountains and off-road terrain!",
                    ImageUrl = "https://www.motofichas.com/images/cache/honda-crf450x-2011-739-a.jpg",
                    CategoryId = 2,
                    PricePerDay = 100.00M
                },
                new Motorbike()
                {
                    Id = 3,
                    BrandId = 4,
                    Model = "Hayabusa",
                    CubicCentimeters = 1300.00M,
                    Description = "This bike is for riding on the road and it's one of the fastest bikes ever!",
                    ImageUrl = "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg",
                    CategoryId = 3,
                    PricePerDay = 200.00M,
                    //RenterId = "4c72c7d3-b589-41aa-93c2-1f834f033f1d"
                },
                new Motorbike()
                {
                    Id = 4,
                    BrandId = 7,
                    Model = "R1250RT",
                    CubicCentimeters = 1250.00M,
                    Description = "This bike is for long and comfortable riding on the road!",
                    ImageUrl = "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg",
                    CategoryId = 4,
                    PricePerDay = 200.00M
                },
                new Motorbike()
                {
                    Id = 5,
                    BrandId = 8,
                    Model = "Street Twin",
                    CubicCentimeters = 900.00M,
                    Description = "This bike is for easy riding on the road!",
                    ImageUrl = "https://imgd.aeplcdn.com/1280x720/bw/models/triumph-street-twin-2021-standard20210401131021.jpg?q=80",
                    CategoryId = 5,
                    PricePerDay = 100.00M,
                    //RenterId = "d005f929-0c1e-43ed-8081-39942b0e0eb2"
                },
                new Motorbike()
                {
                    Id = 6,
                    BrandId = 3,
                    Model = "MT-15",
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
                    Model = "Adventure",
                    CubicCentimeters = 990.00M,
                    Description = "This adventure is for almost any terreain!",
                    ImageUrl = "https://mcn-images.bauersecure.com/wp-images/19502/951x634/990_adventure_dakar.jpg?mode=max&quality=90&scale=down",
                    CategoryId = 7,
                    PricePerDay = 100.00M,
                    //RenterId = "e09e2126-e929-4b57-a3f2-9c30ee774cc8"
                }
            };

            return motorbikes;
        }
    }
}
