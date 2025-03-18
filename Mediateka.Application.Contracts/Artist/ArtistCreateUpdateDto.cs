namespace Mediateka.Application.Contracts.Artist;
/// <summary>
/// Dto для создания или изменения артиста
/// </summary>
/// <param name="Name">Фамилия</param>
/// <param name="Biography">Биография</param>
/// <param name="GenreID">ID жанра</param>
public record ArtistCreateUpdateDto(string? Name, string? Biography, int GenreID);