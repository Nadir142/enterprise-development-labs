using System.ComponentModel.DataAnnotations;
namespace Mediateka.Domain.Model;

/// <summary>
/// Трек
/// </summary>
/// 
public class Track
{
    /// <summary>
    /// Идентификатор трека
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название трека
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Номер в альбоме 
    /// </summary>
    public int? NumberInAlbum { get; set; }

    /// <summary>
    /// Альбом
    /// </summary>
    public virtual Album? Albums { get; set; }

    /// <summary>
    /// Id альбома,связанного с треком
    /// </summary>
    public required int AlbumId { get; set; }



    /// <summary>
    /// Длительность трека(в сек)
    /// </summary>
    public int? Duration { get; set; }

}