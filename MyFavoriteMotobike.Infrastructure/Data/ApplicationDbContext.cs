using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFavoriteMotobike.Infrastructure.Data.Configuration;
using MyFavoriteMotobike.Infrastructure.Data.Entities;

namespace MyFavoriteMotorbike.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new GoldenClientConfiguration());
            builder.ApplyConfiguration(new CategoryCongifuration());
            builder.ApplyConfiguration(new MotorbikeConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CountryOfOriginConfiguration());

            builder
                .Entity<GoldenClient>()
                .HasKey(op => new { op.UserId });
            builder
                .Entity<Motorbike>()
                .HasKey(op => new { op.GoldenClientId, op.RenterId, op.BrandId, op.CategoryId });
            builder
                .Entity<UserMotorbike>()
                .HasOne(m => m.Motorbike)
                .WithMany(um => um.UserMotorbikes)
                .HasForeignKey(m => m.MotorbikeId);

            base.OnModelCreating(builder);
        }
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<CountryOfOrigin> CountriesOfOrigin { get; set; } = null!;
        public DbSet<Motorbike> Motorbikes { get; set; } = null!;
        public DbSet<GoldenClient> GoldenClients { get; set; } = null!;
        public DbSet<UserMotorbike> UserMotorbikes { get; set; } = null!;
    }
}