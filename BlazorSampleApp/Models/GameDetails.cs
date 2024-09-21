using System.ComponentModel.DataAnnotations;

namespace BlazorSampleApp.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name can not be empty")]
    [StringLength(50, ErrorMessage = "Name can not be more than 50 character long")]
    [MinLength(3, ErrorMessage = "Name must be 3 character long")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre can not be empty")]
    public string? GenreId { get; set; }

    [Required(ErrorMessage = "Price can not be empty")]
    [Range(1, 5000, ErrorMessage = "Price must be beteen 1 and 5000")]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
}
