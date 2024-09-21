using Microsoft.EntityFrameworkCore;

namespace BlazorSampleApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
