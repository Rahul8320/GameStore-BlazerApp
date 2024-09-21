using BlazorSampleApp.Data;
using BlazorSampleApp.Models;

namespace BlazorSampleApp.Utils;

public class Mapper(AppDbContext context)
{
    private readonly List<Genre> _genreList = [.. context.Genre];
    public GameSummery ToSummery(GameDetails gameDetails)
    {
        return new GameSummery()
        {
            Id = gameDetails.Id,
            Name = gameDetails.Name,
            Genre = GetGenreName(gameDetails.GenreId),
            Price = gameDetails.Price,
            ReleaseDate = gameDetails.ReleaseDate,
        };
    }

    private string GetGenreName(string? genreId)
    {
        return _genreList.FirstOrDefault(g => g.Id.ToString().Equals(genreId))?.Name ?? throw new Exception("Genre not found!");
    }
}
