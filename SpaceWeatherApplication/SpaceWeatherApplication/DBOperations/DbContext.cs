using Microsoft.EntityFrameworkCore;
using SpaceWeatherApplication.Data;

public class SpaceWeatherDbContext : DbContext
{
    public SpaceWeatherDbContext(DbContextOptions<SpaceWeatherDbContext> options) : base(options)
    {
    }

    public DbSet<SpaceWeather> SpaceWeather { get; set; }
    public DbSet<PlanetData> PlanetData { get; set; }
    public DbSet<SatelliteData> satelliteData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpaceWeather>()
            .HasMany(e => e.PlanetData);

        modelBuilder.Entity<PlanetData>()
            .HasMany(e => e.SatelliteData);
    }



}

