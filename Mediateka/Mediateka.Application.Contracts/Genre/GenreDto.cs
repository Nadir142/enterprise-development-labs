namespace Mediateka.Application.Contracts.Genre;
/// <summary>
/// Dto для просмотра сведений о жаре
/// </summary>
/// <param name="Id">Идентификатор жанра</param>
/// <param name="Name">Название жанра</param>

public record GenreDto(int Id, string? Name);