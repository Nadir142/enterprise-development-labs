namespace Mediateka.Application.Contracts.Artist;
/// <summary>
/// Dto для просмотра сведений об артисте
/// </summary>
/// <param name="Name">Фамилия</param>
/// <param name="Biography">Биография</param>
/// <param name="GenreID">ID жанра</param>
/// <param name="AlbumCount">Количество альбомов</param>
public record ArtistDto(string? Name, string? Biography, int GenreID, int? AlbumCount);