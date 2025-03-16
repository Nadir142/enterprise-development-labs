using System.ComponentModel.DataAnnotations;
namespace Mediateka.Domain.Model;

/// <summary>
/// Жанр
/// </summary>
/// 
public class Genre
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название жанра
    /// </summary>
    public string? Name { get; set; }
}