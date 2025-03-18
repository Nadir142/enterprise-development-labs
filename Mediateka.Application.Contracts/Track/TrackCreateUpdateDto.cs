namespace Mediateka.Application.Contracts.Track;
/// <summary>
/// Dto для создания или изменения трека
/// </summary>
/// <param name="Name">Название трека</param>
/// <param name="NumberInAlbum">Номер в альбоме</param>
/// <param name="AlbumId">ID альбома</param>
/// <param name="Duration">Длительность трека</param>
public record TrackCreateUpdateDto(string? Name, int? NumberInAlbum, int AlbumId, int? Duration);