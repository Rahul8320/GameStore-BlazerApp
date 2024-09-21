using BlazorSampleApp.Data;
using BlazorSampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSampleApp.Clients;

public class GenreClient(AppDbContext context)
{
    public async Task<Genre[]> GetGenresAsync() => await context.Genre.ToArrayAsync();
}
