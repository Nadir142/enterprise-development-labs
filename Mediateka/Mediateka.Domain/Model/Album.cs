using System.ComponentModel.DataAnnotations;
namespace Mediateka.Domain.Model;

/// <summary>
/// Альбом
/// </summary>
/// 
public class Album
{
    // <summary>
    /// Идентификатор альбома
    /// </summary>
    [Key]
    public required int Id { get; set; }

    // <summary>
    /// Название альбома
    /// </summary>
    public string? Name { get; set; }

    // <summary>
    /// Год релиза
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// Список треков в альбоме
    /// </summary>
    public virtual List<Track>? Tracks { get; set; } = [];
    public virtual List<Track>? AlbumID { get; set; } = [];

    /// <summary>
    /// Возвращает количество треков в альбоме
    /// </summary>
    public int? TrackCount => Tracks?.Count;

    /// <summary>
    /// Метод для подсчета общей длительности альбома
    /// </summary>
    public int GetTotalDuration()
    {
        var sum = 0;
        if (Tracks?.Count > 0)
            foreach (var t in Tracks)
                if (t != null && t.Albums != null)
                    sum += t.Duration ?? 0;

        return sum;
    }

}