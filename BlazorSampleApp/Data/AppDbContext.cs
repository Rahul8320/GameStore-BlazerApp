using BlazorSampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSampleApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<GameDetails> GameDetails{ get; set; }
    public DbSet<Genre> Genre{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedGenreData(modelBuilder);
        SeedGameDetailsData(modelBuilder);
    }

    private static void SeedGameDetailsData(ModelBuilder builder)
    {
        builder.Entity<GameDetails>().HasData(
            new()
            {
                Id = 1,
                GenreId = "1",
                Name = "Call of Duty",
                Price = 4999.98M,
                ReleaseDate = new DateOnly(2020, 2, 26)
            },
            new()
            {
                Id = 2,
                GenreId = "5",
                Name = "8 ball poll",
                Price = 68.90M,
                ReleaseDate = new DateOnly(2010, 4, 26)
            },
            new()
            {
                Id = 3,
                GenreId = "4",
                Name = "Subway Surface",
                Price = 500,
                ReleaseDate = new DateOnly(2013, 7, 15)
            }
        );
    }

    private static void SeedGenreData(ModelBuilder builder)
    {
        builder.Entity<Genre>().HasData(
            new Genre()
            {
                Id = 1,
                Name = "Fighting"
            },
            new Genre()
            {
                Id = 2,
                Name = "RolePlaying"
            },
            new Genre()
            {
                Id = 3,
                Name = "Sports"
            },
            new Genre()
            {
                Id = 4,
                Name = "Racing"
            },
            new Genre()
            {
                Id = 5,
                Name = "Kids and Family"
            }
        );
    }
}
