namespace Mediateka.Application.Contracts.Genre;
/// <summary>
/// Dto для создания или изменения жанра
/// </summary>
/// <param name="Name">Название жанра</param>
public record GenreCreateUpdateDto(string? Name);