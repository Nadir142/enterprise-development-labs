using Mediateka.Domain.Model;
namespace Mediateka.Domain.Services;

/// <summary>
/// Наследник обобщенного интерфейса для артистов с дополнительной функциональностью 
/// </summary>
public interface IArtistRepository : IRepository<Artist, int>
{

    /// <summary>
    /// Возвращает информацию о всех артистах в виде списка строк.
    /// </summary>
    public IList<string> GetAllArtisInfo();

    /// <summary>
    /// Метод для вывода артистов с максимальныи количествм альбомов
    /// </summary>
    /// <returns>Список артистов и альбомов</returns>
    public IList<string> GetArtistsWithMaxAlbums();
}