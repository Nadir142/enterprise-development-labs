using System.ComponentModel.DataAnnotations;
namespace Mediateka.Domain.Model;

/// <summary>
/// Артист
/// </summary>
/// 
public class Artist
{
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Имя артиста
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Биография 
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// Id жанра,связанного с артистом
    /// </summary>
    public required int GenreID { get; set; }

    /// <summary>
    /// Жанр
    /// </summary>
    public virtual Genre? Genre { get; set; }

    /// <summary>
    /// Список альбомов
    /// </summary>
    public virtual List<Album>? Albums { get; set; } = [];

    /// <summary>
    /// Возвращает количество альбомов
    /// </summary>
    public int? AlbumCount => Albums?.Count;
}