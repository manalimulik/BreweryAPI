using BreweryAPI;
using BreweryAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


    var serviceProvider = builder.Services.BuildServiceProvider();
    var logger = serviceProvider.GetService<ILogger<LoggerFactory>>();
builder.Services.AddSingleton(typeof(ILogger), logger);
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBreweryService, BreweryService>();
builder.Services.AddScoped<IBarService, BarService>();
builder.Services.AddScoped<IBreweryAndBeerInfoService, BreweryAndBeerInfoService>();
builder.Services.AddScoped<IBarAndBeerInfoService, BarAndBeerInfoService>();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
