using BlazorSampleApp.Models;

namespace BlazorSampleApp.Clients;

public class GameClient
{
    private readonly List<GameSummery> games = [
        new(){
            Id = 1,
            Genre = "Fighting",
            Name = "Call of Duty",
            Price = 4999.98M,
            ReleaseDate = new DateOnly(2020, 2,26)
        },
        new(){
            Id = 2,
            Genre = "Kids and Family",
            Name = "8 ball poll",
            Price = 68.90M,
            ReleaseDate = new DateOnly(2010, 4,26)
        },
        new(){
            Id = 3,
            Genre = "Racing",
            Name = "Subway Surface",
            Price = 500,
            ReleaseDate = new DateOnly(2013, 7,15)
        },
    ];

    private readonly Genre[] genres = new GenreClient().GetGenres();

    public List<GameSummery> GetGames() => [.. games.OrderBy(game => game.ReleaseDate)];

    public GameDetails GetGameDetails(int id)
    {
        var game = GetGameSummery(id);
        var genre = GetGenreByName(game.Genre);

        return new GameDetails()
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }

    public void AddGame(GameDetails game)
    {
        var genre = GetGenreById(game.GenreId);

        GameSummery gameSummery = new()
        {
            Id = GenerateRandomId(),
            Name = game.Name,
            Price = game.Price,
            Genre = genre.Name,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummery);
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        var existingGame = GetGameSummery(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummery(id);
        games.Remove(game);
    }

    private static int GenerateRandomId()
    {
        // Get the current timestamp in milliseconds
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Use the timestamp to seed a random number generator
        Random random = new((int)(timestamp % int.MaxValue));

        // Generate a random integer in the full int range
        int randomId = random.Next();

        return randomId;
    }

    private Genre GetGenreByName(string genreName)
    {
        return genres.Single(genre => string.Equals(genre.Name, genreName, StringComparison.OrdinalIgnoreCase));
    }

    private GameSummery GetGameSummery(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? genreId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(genreId);

        return genres.Single(item => item.Id == int.Parse(genreId));
    }
}
