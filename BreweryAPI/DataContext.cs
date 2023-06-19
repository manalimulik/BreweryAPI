using BreweryAPI.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BreweryAPI
{
    public class DataContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("BreweryDB"));
        }
       
        public DbSet<Bar> Bar { get;set;}
        public DbSet<BarAndBeerInfo> BarAndBeerInfo { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Brewery> Brewery { get; set; }
        public DbSet<BreweryAndBeerInfo> BreweryAndBeerInfo { get; set; }

    }
}
