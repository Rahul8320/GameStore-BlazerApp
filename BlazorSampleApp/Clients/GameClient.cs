using BlazorSampleApp.Data;
using BlazorSampleApp.Models;
using BlazorSampleApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace BlazorSampleApp.Clients;

public class GameClient(AppDbContext context, Mapper mapper)
{
    public async Task<List<GameSummery>> GetGamesAsync()
    {
        var gameDetailsList = await context.GameDetails.AsNoTracking().OrderBy(g => g.ReleaseDate).ToListAsync();

        var gameSummeryList = new List<GameSummery>();

        foreach (var gameDetails in gameDetailsList)
        {
            gameSummeryList.Add(mapper.ToSummery(gameDetails));
        }

        return gameSummeryList;
    }

    public async Task<GameDetails> GetGameDetailsAsync(int id)
    {
        return await context.GameDetails.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id)
            ?? throw new Exception("Game details not found!");
    }

    public async Task AddGameAsync(GameDetails game)
    {
        await context.GameDetails.AddAsync(game);
        await context.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(GameDetails updatedGame)
    {
        var existingGame = await GetGameDetailsAsync(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.GenreId = updatedGame.GenreId;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;

        context.GameDetails.Update(existingGame);
        await context.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await GetGameDetailsAsync(id);
        context.GameDetails.Remove(game);
        await context.SaveChangesAsync();
    }
}
