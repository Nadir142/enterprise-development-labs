using Mediateka.Domain.Model;
namespace Mediateka.Domain.Services;
/// <summary>
/// Наследник обобщенного интерфейса для альбомов с дополнительной функциональностью 
/// </summary>
public interface IALbumRepository : IRepository<Album, int>
{
    /// <summary>
    /// Возвращает список треков для указанного альбома
    /// </summary>
    /// <param name="AlbumId">ID альбома.</param>
    /// <returns>Список строк с информацией о треках.</returns>
    //public IList<Tuple<string, int>> GetTreksInAlbum();
    public IList<string> GetTreksInAlbum(int AlbumId);


    /// <summary>
    /// Возвращает список треков для указанного альбома
    /// </summary>
    /// <param name="Year">Год выпуска.</param>
    public IEnumerable<(string AlbumName, int TrackCount)> GetAlbumsWithTrackCount(int year);

    /// <summary>
    /// Возвращает топ-5  альбомов по продолжительности
    /// </summary>
    public IList<Tuple<string, int>> GetTop5AlbumsByDuration();

    /// <summary>
    /// Получить информацию о количестве треков, среднем и максимальной дляительности для каждого альбома.
    /// </summary>
    /// <returns>Список с минимальной, средней и максимальной длительностью альбомов.</returns>
    //(int MinDuration, double AverageDuration, int MaxDuration) GetAlbumDurationStatistics();
    public Task<IList<(Album album, int MinDuration, double avgDuration, int maxDuration)>> GetAlbumDurationStatistics();

}
