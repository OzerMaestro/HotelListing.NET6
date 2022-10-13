using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData( 
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
        }
    }
}
