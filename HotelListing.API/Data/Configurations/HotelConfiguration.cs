using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
