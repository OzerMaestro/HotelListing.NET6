using HotelListing.API.Configurations;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Interfaces;
using Microsoft.AspNetCore.Identity;
using HotelListing.API.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");
builder.Services.AddDbContext<HotelListingDbContext>(options =>
{
    options.UseSqlServer(connString);
});

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HotelListingDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Host.UseSerilog((HostBuilderContext, LoggerConfig) => LoggerConfig.WriteTo.Console().ReadFrom.Configuration(HostBuilderContext.Configuration));

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
