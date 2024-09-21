using BlazorSampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSampleApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Student { get; set; } = default!;
}
