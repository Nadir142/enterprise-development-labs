namespace Mediateka.Application.Contracts.Album;
/// <summary>
/// Dto для просмотра сведений об альбоме
/// </summary>
/// <param name="Name">Название альбома</param>
/// <param name="Year">Год релиза</param>
/// <param name="TrackCount">Количетсво треков</param>
public record AlbumDto(string? Name, int? Year, int? TrackCount);