using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Configuration;
using MyFavoriteMotobike.Infrastructure.Data.Entities;
using MyFavoriteMotorbike.Infrastructure.Data.Entities;

namespace MyFavoriteMotorbike.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<CountryOfOrigin> CountriesOfOrigin { get; set; } = null!;
        public DbSet<Motorbike> Motorbikes { get; set; } = null!;
        public DbSet<GoldenClient> GoldenClients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new GoldenClientConfiguration());
            builder.ApplyConfiguration(new CategoryCongifuration());
            builder.ApplyConfiguration(new MotorbikeConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CountryOfOriginConfiguration());

            base.OnModelCreating(builder);
        }
    }
}