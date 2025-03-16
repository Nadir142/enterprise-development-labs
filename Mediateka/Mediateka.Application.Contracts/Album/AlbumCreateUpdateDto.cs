namespace Mediateka.Application.Contracts.Album;
/// <summary>
/// Dto для создания или изменения альбома
/// </summary>
/// <param name="Name">Название альбома</param>
/// <param name="Year">Год релиза</param>
public record AlbumCreateUpdateDto(string? Name, int? Year);