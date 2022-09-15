using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    CountryName = "Turkey",
                    ShortName = "TR",
                },
                new Country
                {
                    CountryId = 2,
                    CountryName = "Denmark",
                    ShortName = "DK",
                },
                new Country
                {
                    CountryId = 3,
                    CountryName = "Sweden",
                    ShortName = "SWE",
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    HotelId = 1,
                    Name = "Four Seasons",
                    Address = "Kayseri",
                    CountryId = 1,
                    Rating = 5
                },
                new Hotel
                {
                    HotelId = 2,
                    Name = "Mariot",
                    Address = "Copenhagen",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel
                {
                    HotelId = 3,
                    Name = "Cabinn",
                    Address = "Malmö",
                    CountryId = 3,
                    Rating = 3
                }
            );
        }
    }
}
